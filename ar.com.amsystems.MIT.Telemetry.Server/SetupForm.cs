using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ar.com.amsystems.Telemetry.Server.Helpers;
using ar.com.amsystems.Telemetry.Server.Properties;
using ar.com.amsystems.Telemetry.Server.Setup;

namespace ar.com.amsystems.Telemetry.Server
{
    public partial class SetupForm : Form
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        bool _setupFinished;

        readonly Dictionary<ISetup, PictureBox> _setupStatusImages = new Dictionary<ISetup, PictureBox>();

        public SetupForm()
        {
            InitializeComponent();

            DialogResult = DialogResult.OK;

            string sApiPort = ConfigurationManager.AppSettings["ApiPort"];
            if (Program.UninstallMode)
            {
                pluginStatusLabel.Text = @"Desinstalar PlugIns MIT ETS2";
                firewallStatusLabel.Text = $@"Borrar regla de Firewall puerto {sApiPort}";
                urlReservationStatusLabel.Text = $@"Borrar regla ACL para Api http://+:{sApiPort}/";
                okButton.Text = @"Desinstalar";
            }
            else
            {
                pluginStatusLabel.Text = @"Instalar PlugIns MIT para ETS2";
                firewallStatusLabel.Text = $@"Agregar regla de Firewall puerto {sApiPort}";
                urlReservationStatusLabel.Text = $@"Agregar regla ACL para Api http://+:{sApiPort}/";
                okButton.Text = @"Instalar";
            }
        }

        void SetStepStatus(ISetup step, SetupStatus status)
        {
            SetupStatus inverseStatus = status;
            if (Program.UninstallMode)
            {
                switch (status)
                {
                    case SetupStatus.Instalado:
                        inverseStatus = SetupStatus.Desinstalado;
                        break;
                    case SetupStatus.Desinstalado:
                        inverseStatus = SetupStatus.Instalado;
                        break;
                }
            }
            // convert status enumeration to images
            Bitmap statusImage = inverseStatus == SetupStatus.Desinstalado
                                     ? Resources.StatusIcon
                                     : (inverseStatus == SetupStatus.Instalado
                                            ? Resources.SuccessStatusIcon
                                            : Resources.FailureStatusIcon);
            if (_setupStatusImages.ContainsKey(step))
                _setupStatusImages[step].Image = statusImage;
        }
        
        private void SetupForm_Load(object sender, EventArgs e)
        {
            // show application version 
            Text += @" " + AssemblyHelper.Version + @" - Setup";

            // make sure that game is not running
            if (Ets2ProcessHelper.IsEts2Running)
            {
                MessageBox.Show(this,
                    @"El Simulador MOD ETS2 no esta corriendo." + Environment.NewLine +
                    @"Por favor cerrar todo y volver abrir.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Abort;
                return;
            }

            // make sure that we have Administrator rights
            if (!Uac.IsProcessElevated())
            {
                try
                {
                    // we have to restart the setup with Administrator privileges
                    Uac.RestartElevated();
                    DialogResult = DialogResult.Abort;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
                finally
                {
                    // if succeeded or user declined elevation 
                    // then we just exit from the current process
                    Environment.Exit(0);
                }
            }
            
            // update UI 
            foreach (var step in Instalador.Procedimiento)
            {
                if (step is SetupStatus)
                    _setupStatusImages.Add(step, pluginStatusImage);
                else if (step is FirewallSetup)
                    _setupStatusImages.Add(step, firewallStatusImage);
                else if (step is UrlReservationSetup)
                    _setupStatusImages.Add(step, urlReservationStatusImage);
                SetStepStatus(step, step.Estado);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okButton.Enabled = false;
            _setupFinished = true;

            foreach (var step in Instalador.Procedimiento)
            {
                try
                {
                    SetStepStatus(step, Program.UninstallMode ? step.Desinstalar(this) : step.Instalar(this));
                }
                catch (Exception ex)
                {
                    _setupFinished = false;
                    Log.Error(ex);
                    ex.ShowAsMessageBox(this, @"Error de instalación");
                }
            }

            string message;
            if (_setupFinished)
            {
                message = Program.UninstallMode
                              ? @"El server ha sido desinstalado correctamente. " + Environment.NewLine +
                                @"Presione OK para salir. "
                              : @"El server ha sido instalado correctamente. " + Environment.NewLine +
                                "Presione OK para levantar el Server. ";
            }
            else
            {
                message = Program.UninstallMode
                              ? @"Server has been uninstalled with errors. " + Environment.NewLine +
                                @"Press OK to exit."
                              : @"Server has been installed with errors. " + Environment.NewLine +
                                "Press OK to start the server.";
            }

            if (Program.UninstallMode)
                Helpers.MIT_NetRacer_Config.Clear();

            MessageBox.Show(this, message, @"Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing || Program.UninstallMode)
                DialogResult = DialogResult.Abort;
        }

        private void helpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessHelper.OpenUrl("http://www.amsystems.com.ar");
        }
    }
}
