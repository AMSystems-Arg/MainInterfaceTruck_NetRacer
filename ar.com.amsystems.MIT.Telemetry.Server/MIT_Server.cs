using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ar.com.amsystems.Telemetry.Server.Controllers;
using ar.com.amsystems.Telemetry.Server.Data;
using ar.com.amsystems.Telemetry.Server.Data.FormularioToDB;
using ar.com.amsystems.Telemetry.Server.Helpers;
using ar.com.amsystems.Telemetry.Server.Setup;
using Microsoft.Owin.Hosting;

namespace ar.com.amsystems.Telemetry.Server
{
    public partial class MIT_Server : Form
    {
        IDisposable _server;
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        readonly HttpClient _broadcastHttpClient = new HttpClient();
        static readonly Encoding Utf8 = new UTF8Encoding(false);
        static readonly string sBroadcastUrl = ConfigurationManager.AppSettings["BroadcastUrl"];
        static readonly string sBroadcastUserId = Convert.ToBase64String(Utf8.GetBytes(ConfigurationManager.AppSettings["BroadcastUserId"] ?? ""));
        static readonly string sBroadcastUserPassword = Convert.ToBase64String(Utf8.GetBytes(ConfigurationManager.AppSettings["BroadcastUserPass"] ?? ""));
        static readonly int BroadcastRateInSeconds = Math.Min(Math.Max(1, Convert.ToInt32(ConfigurationManager.AppSettings["BroadcastRate"])), 86400);
        static readonly bool UseTestTelemetryData = Convert.ToBoolean(ConfigurationManager.AppSettings["MIT_NetRacerTestTelemetryData"]);

        public MIT_Server()
        {
            InitializeComponent();
        }

        static string sIpToEndpointUrl(string dominio)
        {
            return $"http://{dominio}:{ConfigurationManager.AppSettings["ApiPort"]}";
        }

        //Instalador/Desinstalador del Proceso Server
        void Setup()
        {
            //Seteo del timer de actualización de datos con el plugins MIT (Default 3000).
            this.statusUpdateTimer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["MIT-Server_Intervalo_de_Actualización_Plugins"]);
            Log.Info("Intervalo de actualización de datos: " + this.statusUpdateTimer.Interval.ToString() +" ms.");

            try
            {
                if (Program.UninstallMode && Instalador.Procedimiento.All(s => s.Estado == SetupStatus.Desinstalado))
                {
                    MessageBox.Show(this, @"MainInterfazTruck_Netracer Server no esta instalado!, no se desinstalará.", @"Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }

                if (Program.UninstallMode || Instalador.Procedimiento.Any(s => s.Estado != SetupStatus.Instalado))
                {
                    // Espero hasta que la instalación Termine.
                    var result = new SetupForm().ShowDialog(this);
                    if (result == DialogResult.Abort)
                        Environment.Exit(0);
                }

                // Aumentar la prioridad para que el servidor sea más receptivo (¡aunque no consume CPU!)
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ex.ShowAsMessageBox(this, @"Error en la Instalación.");
            }
        }

        //Levanto proceso.
        void Start()
        {
            try
            {
                // Cargo listado de interfaces de Red Disponibles.
                var networkInterfaces = NetworkHelper.GetAllActiveNetworkInterfaces();
                interfacesDropDown.Items.Clear();
                foreach (var varNetInterfaz in networkInterfaces)
                    interfacesDropDown.Items.Add(varNetInterfaz);
                // selecciono la interface o seteo la default
                var varSelInterface = networkInterfaces.FirstOrDefault(
                    i => i.Id == MIT_NetRacer_Config.sInstancia.DefaultNetworkInterfaceId);
                if (varSelInterface != null)
                    interfacesDropDown.SelectedItem = varSelInterface;
                else
                    interfacesDropDown.SelectedIndex = 0; // selecciono interface por defecto.

                // Bindeo todas las interfaces de Red disponibles
                _server = WebApp.Start<Startup>(sIpToEndpointUrl("+"));

                // Arranco proceso server (timer watchdog)
                statusUpdateTimer.Enabled = true;

                // Enciendo broadcasting (si es que esta seteado)
                if (!string.IsNullOrEmpty(sBroadcastUrl))
                {
                    _broadcastHttpClient.DefaultRequestHeaders.Add("X-UserId", sBroadcastUserId);
                    _broadcastHttpClient.DefaultRequestHeaders.Add("X-UserPassword", sBroadcastUserPassword);
                    broadcastTimer.Interval = BroadcastRateInSeconds * 1000; //(Conversion de MS a Seg)
                    broadcastTimer.Enabled = true;
                }

                // Muestro icono en la barra
                trayIcon.Visible = true;
                
                // Activo formulario visible.
                Activate();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ex.ShowAsMessageBox(this, @"Error de Comunicacion", MessageBoxIcon.Exclamation);
            }
        }
        
        void MainForm_Load(object sender, EventArgs e)
        {
            //start minimizado
            this.WindowState = FormWindowState.Minimized;

            //Oculto Opciones no disponibles:
            this.appUrlTitleLabel.Visible = false;
            this.apiEndpointUrlTitleLabel.Visible = false;
            this.appUrlLabel.Visible = false;
            this.apiUrlLabel.Visible = false;

            // (Para Debbug, Log de la version actual)
            Log.InfoFormat("Corriendo MainInterfaceTruckServer en {0} ({1}) {2}", Environment.OSVersion, 
                Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit",
                Program.UninstallMode ? "[Modo Desinstalación]" : "");
            Text += @" " + AssemblyHelper.Version;

            // Instalo o Desinstalo el proceso Server
            Setup();

            // Levanto el Server (WebApi)
            Start();

            //Post Start MIT
            validate();

            //Levanto MIT Report
            Interfaz_Main mIMain = new Interfaz_Main();
            mIMain.Show();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Salir          
        }
    
        void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        //TIMER DE ESTADO DEL PLUGINS MIT con el Mod.
        int count = 0;
        void statusUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // status con el plugins del MOD
                if (UseTestTelemetryData)
                {
                    statusLabel.Text = @"MainInterfaceTruckServer Conectado (Ets2TestTelemetry.json)";
                    statusLabel.ForeColor = Color.DarkGreen;
                } 
                else if (Ets2TelemetryDataReader.Instance.IsConnected && Ets2ProcessHelper.IsEts2Running)
                {
                    statusLabel.Text = $"Plugin Conectado y Simulador corriendo ({Ets2ProcessHelper.LastRunningGameName})";
                    statusLabel.ForeColor = Color.DarkGreen;
                }
                else if (Ets2ProcessHelper.IsEts2Running)
                {
                    statusLabel.Text = $"El Simulador está corriendo ({Ets2ProcessHelper.LastRunningGameName})";
                    statusLabel.ForeColor = Color.Teal;
                }
                else
                {
                    statusLabel.Text = @"El Simulador no está corriendo.";
                    statusLabel.ForeColor = Color.FromArgb(240, 55, 30);
                }
                if (count < 1)
                {   //Process del MOD
                    Log.Info("Estado de conexión con el PlugIns MIT: " + statusLabel.Text);
                    count++;
                }

                //>>>>>>>>>>>>>>>>  Actualizá el Reporte <<>>>>>>>>>>>>>>>>>>
                //mActualizarReport();


            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ex.ShowAsMessageBox(this, @"Error del Proceso MainInterfaceTruckServer ", MessageBoxIcon.Error);
                statusUpdateTimer.Enabled = false;
            }
        }

        private void validate()
        {
            try
            {
                // version del MOD
                string sVersion = $"EST2 ({Ets2ProcessHelper.sEts2Version})";
                Log.Info("Corriendo versión del MOD " + sVersion);
                lbl_versionEST2.Text = sVersion;
            }
            catch (Exception er)
            {
                string error = @"Error al leer parametros del MOD mediante el PlugIns MIT";
                Log.Error(error);
                er.ShowAsMessageBox(this, error, MessageBoxIcon.Error);
            }
        }

        void apiUrlLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessHelper.OpenUrl(((LinkLabel)sender).Text);
        }

        void appUrlLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessHelper.OpenUrl(((LinkLabel)sender).Text);
        }
        
        void MainForm_Resize(object sender, EventArgs e)
        {
                ShowInTaskbar = WindowState != FormWindowState.Minimized;
                if (!ShowInTaskbar && trayIcon.Tag == null)
                {
                    trayIcon.ShowBalloonTip(1000, @"MainInterfaceTruckServer", @"Double-click para restaurar ventana.", ToolTipIcon.Info);
                    trayIcon.Tag = "Mostrar Siempre";
                }
        }       

        void interfacesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var varSelInterface = (NetworkInterfaceInfo) interfacesDropDown.SelectedItem;
            ipAddressLabel.Text = varSelInterface.Ip; //IP de la interface seleccionada.
            appUrlLabel.Text = sIpToEndpointUrl(varSelInterface.Ip) + Ets2AppController.TelemetryAppUriPath; //IP + Contexto APP
            apiUrlLabel.Text = sIpToEndpointUrl(varSelInterface.Ip) + Ets2TelemetryController.TelemetryApiUriPath; //IP + Contexto API
            MIT_NetRacer_Config.sInstancia.DefaultNetworkInterfaceId = varSelInterface.Id;
            MIT_NetRacer_Config.sInstancia.SmSave();
        }

        async void broadcastTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                broadcastTimer.Enabled = false;
                await _broadcastHttpClient.PostAsJsonAsync(sBroadcastUrl, Ets2TelemetryDataReader.Instance.Read());
            }
            catch (Exception ex)
            {
                Log.Error("Error de comunicacion con la Instancia del plugin MIT, detalle: " + ex);
            }
            broadcastTimer.Enabled = true;
        }
        
        void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exeFileName = Process.GetCurrentProcess().MainModule.FileName;
            var startInfo = new ProcessStartInfo
            {
                Arguments = $"/C ping 127.0.0.1 -n 2 && \"{exeFileName}\" -uninstall",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(startInfo);
            Application.Exit();
        }

        void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crear Interfaz de Ayuda. y dirigir a sitio:
            ProcessHelper.OpenUrl("http://www.netracer.com.ar");
        }

        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear Interfaz About con logo del producto, datos de contactos  etc.
            MessageBox.Show("Ups, en desarrollo.", "DEMO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MIT_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            var result = MessageBox.Show("¿Desea cerrar MIT Server y Reporte?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            e.Cancel = (result == DialogResult.No);
        }
    }
}
