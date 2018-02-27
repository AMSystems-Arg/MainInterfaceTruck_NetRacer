using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ar.com.amsystems.Telemetry.Server.Controllers
{
    class MIT_Printers
    {
        //Método para imprimir Reporte (desde modo imagen):
        public void m_Print_Pic(){
            PrintDocument PrintDoc = new PrintDocument();
            PrintDoc.PrintPage += new PrintPageEventHandler(mEvent_PrintImage);
            PrintDoc.Print();
        }

        private void mEvent_PrintImage(object sender, PrintPageEventArgs e)
        {
            PictureBox oPic = new PictureBox();
            e.Graphics.DrawImage(oPic.Image, 0, 0);
            throw new NotImplementedException();
        }
    }
}
