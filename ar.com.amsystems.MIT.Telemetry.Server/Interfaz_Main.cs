using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using ar.com.amsystems.Telemetry.Server.Data;
using ar.com.amsystems.Telemetry.Server.Data.FormularioToDB;
using ar.com.amsystems.Telemetry.Server.Helpers;

namespace ar.com.amsystems.Telemetry.Server
{
    public partial class Interfaz_Main : Form
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); //Log

        public bool bControl_MitServerTelemetry;

        //Root Path App
        string s_PathRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")); //Dos directorio atras.

        public Interfaz_Main()
        {
            InitializeComponent();
            //Levanto config inicial
            start_up();
        }

        private void start_up()
        {
            //Foto Carnet:
            this.Text = "MIT (Vial Simulación) " + AssemblyHelper.Version;
            this.img_carnet.SizeMode = PictureBoxSizeMode.StretchImage;
            this.img_carnet.BorderStyle = BorderStyle.FixedSingle;
            this.foto_reporte.SizeMode = PictureBoxSizeMode.StretchImage;
            this.foto_reporte.BorderStyle = BorderStyle.None;
            this.txt_nombre.MaxLength = 40;
            this.txt_apellido.MaxLength = 40;
            this.txt_dni.MaxLength = 12;
            this.combo_capa.SelectedIndex = 0;
            this.txt_conductor.Text = "";
            this.txt_docDni.Text = "";
            this.txt_capa.Text = "";
            this.txt_choqueAutos.Text = "Esperando...";
            this.txt_choques.Text = "Esperando...";
            this.txt_estacionarFacil.Text = "Esperando...";
            this.txt_EstacionarDif.Text = "Esperando...";
            this.txt_fueracamino.Text = "Esperando...";
            this.txt_infracciones.Text = "Esperando...";
            this.lbl_kmRecorrido.Text = "Esperando...";
            this.txt_limitcamino.Text = "Esperando...";
            this.txt_ltrsConsumidos.Text = "Esperando...";
            this.txt_multaVelocidad.Text = "Esperando...";
            this.txt_salidasFallidas.Text = "Esperando...";
            timerActualizarReporte.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["MIT-Server_Intervalo_de_Actualización_Reporte"]);
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Salir
            if (MessageBox.Show("¿Desea cerrar MIT Server y Reporte?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_carnet_Click(object sender, EventArgs e)
        {
            //Cargo dialog busqueda de la foto.
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Seleccionar y Cargar Foto Carnet";
                dlg.Filter = "Archivos de Imagenes (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //PictureBox PictureBox1 = new PictureBox();
                    //PictureBox1.Image = new Bitmap(dlg.FileName);
                    this.img_carnet.Image = new Bitmap(dlg.FileName);
                }
            }

        }

        private static void msj_noDisponible()
        {
            MessageBox.Show("Opción no disponible en esta versión.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menu_manual_Click(object sender, EventArgs e)
        {
            //msj_noDisponible();
            //Ruta Manual PDF
            try
            {
                System.Diagnostics.Process.Start(s_PathRoot + @"\Resources\Manual de Uso_VialSimuladores_ver1.0.pdf");
            }
            catch (Exception er)
            {
                Log.Error("Error en el lector de PDF, detalle: " + er.ToString());
                MessageBox.Show("Error en el lector de PDF, detalle: " + er.ToString(), "No se pudo abrir el manual pdf", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_contacto_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(s_PathRoot + @"\Html\Contact_html.html");
            }
            catch (Exception er)
            {
                Log.Error("Error al abrir instancia contacto, detalle: " + er.ToString());
                MessageBox.Show("Error al abrir instancia contacto, detalle: " + er.ToString(), "No se pudo abrir el contacto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_licencia_Click(object sender, EventArgs e)
        {
            //msj_noDisponible();
            string sCode = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su codigo de activación de 20 Digitos", "Licencia");
            ModSecurity mMod = new ModSecurity();
            if (mMod.mHash256(sCode) == true){
                //Code Hash Validado OK, puede usar la APP.
                MessageBox.Show("Código de Activación [Correcto]. Gracias por su compra.", "Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Info("Código de Activación [Correcto]");
                menu_licencia.Image = Properties.Resources.SuccessStatusIcon;
            }
            else { MessageBox.Show("Código de Activación [Incorrecto]. Contactarse con Netracer (Vial Simuladores).", "Licencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Warn("Código de Activación [Incorrecto]");
                Application.Exit();
            }
            
        }

        private void group_Main_Enter(object sender, EventArgs e)
        { }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            //Renderizo Reporte:
            preload_data_toPrint();
            //Borro datos de reporte del anterior conductor
            this.countVel = 0;

            //Guardo datos cargados en DB.
            var_dataForm mdataForm = new var_dataForm();
            mdataForm.s_Name = this.txt_nombre.ToString();
            mdataForm.s_lastname = this.txt_apellido.ToString();
            mdataForm.s_dni = this.txt_dni.ToString();
            mdataForm.s_capa = this.combo_capa.SelectedItem.ToString();

            //Datos del Conductor cargado Manualmente:
            this.txt_conductor.Text = this.txt_nombre.Text.ToString() + " " + this.txt_apellido.Text.ToString();
            this.txt_docDni.Text = this.txt_dni.Text.ToString();
            this.txt_capa.Text = this.combo_capa.SelectedItem.ToString();
            this.foto_reporte.Image = this.img_carnet.Image;

        }

        private void preload_data_toPrint()
        {
            this.txt_choqueAutos.Text = "Esperando...";
            this.txt_choques.Text = "Esperando...";
            this.txt_estacionarFacil.Text = "Esperando...";
            this.txt_estacionarFacil.Text = "Esperando...";
            this.txt_fueracamino.Text = "Esperando...";
            this.txt_infracciones.Text = "Esperando...";
            this.lbl_kmRecorrido.Text = "Esperando...";
            this.txt_limitcamino.Text = "Esperando...";
            this.txt_ltrsConsumidos.Text = "Esperando...";
            this.txt_multaVelocidad.Text = "Esperando...";
            this.txt_salidasFallidas.Text = "Esperando...";

            bControl_MitServerTelemetry = true;
        }

        private void after_report_toPrint()
        {
            //Por bug en el render a la hora de imprimir se llevan al fondo de la 
            //imagen del reporte todos los objetos para su correcta visualización en impresion.
            this.foto_reporte.SendToBack();
            this.txt_conductor.SendToBack();
            this.txt_docDni.SendToBack();
            this.txt_capa.SendToBack();
            this.lbl_kmRecorrido.SendToBack();
            this.txt_choqueAutos.SendToBack();
            this.img_camionesManejados.SendToBack();
            this.txt_choques.SendToBack();
            this.txt_salidasFallidas.SendToBack();
            this.txt_EstacionarDif.SendToBack();
            this.txt_estacionarFacil.SendToBack();
            this.txt_fueracamino.SendToBack();
            this.txt_infracciones.SendToBack();
            this.txt_limitcamino.SendToBack();
            this.txt_ltrsConsumidos.SendToBack();
            this.txt_multaVelocidad.SendToBack();

            this.btn_imprimir.BringToFront();
        }

        private void btn_imprimir_Click1(object sender, EventArgs e)
        {
            m_Print_Reporte();
        }

        //[STAThread]
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1 && !bControl_MitServerTelemetry)
            {
                //Renderizo Reporte:
                preload_data_toPrint();
            }
        }


        private void serverMITEstadoSetup_Click(object sender, EventArgs e)
        {
            MIT_Server mMITServer = new MIT_Server();
            if (mMITServer.ShowInTaskbar)
            {
                mMITServer.Show();

            }
        }

        
        [STAThread]
        //Método para imprimir Reporte (desde modo imagen):
        public void m_Print_Reporte()
        {
            try
            {
                PrintDocument oPrintDoc = new PrintDocument();
                oPrintDoc.PrintPage += new PrintPageEventHandler(mEvent_PrintImage);
                oPrintDoc.Print();
                Log.Info("Se envio correctamente el reporte MIT a la cola de impresión ");


            }
            catch (Exception er)
            {
                Log.Error("Se produjo un error al intentar imprimir el reporte, detalle " + er.ToString());
                MessageBox.Show("Se produjo un error al intentar imprimir el reporte, detalle " + er.ToString(), "Preparando Impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mEvent_PrintImage(object sender, PrintPageEventArgs e)
        {
            //float x = e.MarginBounds.Left;
            //float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupReporte.Width, this.groupReporte.Height);
            this.groupReporte.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupReporte.Width, this.groupReporte.Height));
            e.Graphics.DrawImage((Image)bmp, 0, 0);
        }

        private void menu_imprimir_Click(object sender, EventArgs e)
        {
            after_report_toPrint();
            m_Print_Reporte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MIT_Server oMitServer = new MIT_Server();
            
        }

        private void timerActualizarReporte_Tick(object sender, EventArgs e)
        {
            //>>>>>>>>>>>>>>>>  Actualizá el Reporte <<>>>>>>>>>>>>>>>>>>
            mActualizarReport();
        }
        int countVel;
        [STAThread] //Analizar metrica si es bueno esto o no para q en un hilo aparte actualice los datos del reporte.
        private void mActualizarReport()
        {
            var_dataForm oDataform = new var_dataForm();
            Log.Debug("Inicio de Actualización de datos del Reporte...");
            var oMit = Ets2TelemetryDataReader.Instance.Read();
            this.lbl_kmRecorrido.Text = (Math.Round(oMit.Trayecto.f_velocimetro, 2)).ToString(); //float con 2 dig.
            this.txt_ltrsConsumidos.Text = (Math.Round(oMit.Trayecto.FuelAverageConsumption, 2)).ToString();
            this.txt_infracciones.Text = "0";//iInfracciones.ToString();
            //this.img_camionesManejados.Image = 
            this.txt_salidasFallidas.Text = (oMit.Trayecto.RetarderStepCount).ToString(); 
            this.txt_fueracamino.Text = "0";
            this.txt_choques.Text = "0";
            this.txt_choqueAutos.Text = "0";
            this.txt_limitcamino.Text = "0";
            if (oMit.Trayecto.f_VelocidadCrucero > 75) { this.txt_multaVelocidad.Text = countVel++.ToString(); } else { this.txt_multaVelocidad.Text = countVel.ToString();};
            this.txt_estacionarFacil.Text = (oMit.Recorrido.EstimatedTime).ToString();
            this.txt_EstacionarDif.Text = (oMit.Recorrido.EstimatedTime).ToString();
            Log.Debug("Fin de la Actualización de datos del Reporte.");
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            after_report_toPrint();
            m_Print_Reporte();
        }
        private void img_reporte_Click(object sender, EventArgs e)
        {
            //Por bug en el render a la hora de imprimir se llevan al fondo de la 
            //imagen del reporte todos los objetos para su correcta visualización en impresion.
            this.foto_reporte.BringToFront();
            this.txt_conductor.BringToFront();
            this.txt_docDni.BringToFront();
            this.txt_capa.BringToFront();
            this.lbl_kmRecorrido.BringToFront();
            this.txt_choqueAutos.BringToFront();
            this.img_camionesManejados.BringToFront();
            this.txt_salidasFallidas.BringToFront();
            this.txt_choques.BringToFront();
            this.txt_EstacionarDif.BringToFront();
            this.txt_estacionarFacil.BringToFront();
            this.txt_fueracamino.BringToFront();
            this.txt_infracciones.BringToFront();
            this.txt_limitcamino.BringToFront();
            this.txt_ltrsConsumidos.BringToFront();
            this.txt_multaVelocidad.BringToFront();

            this.btn_imprimir.BringToFront();
        }
    }
}