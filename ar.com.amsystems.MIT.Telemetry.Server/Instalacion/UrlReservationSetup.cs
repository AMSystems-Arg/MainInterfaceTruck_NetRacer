using System;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;
using ar.com.amsystems.Telemetry.Server.Helpers;

namespace ar.com.amsystems.Telemetry.Server.Setup
{
    public class UrlReservationSetup : ISetup
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        SetupStatus _status;
        
        public UrlReservationSetup()
        {
            try
            {
                if (MIT_NetRacer_Config.sInstancia.UrlReservationSetupHadErrors)
                {
                    _status = SetupStatus.Instalado;
                }
                else
                {
                    string sApiPort = ConfigurationManager.AppSettings["ApiPort"];
                    string arguments = $@"http show urlacl url=http://+:{sApiPort}/";
                    Log.Info("Verificando estado de la URL ACL...");
                    string output = ProcessHelper.RunNetShell(arguments, "Fallo la verificacion de estado de la URL ACL. ");
                    _status = output.Contains(sApiPort) ? SetupStatus.Instalado : SetupStatus.Desinstalado;    
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                _status = SetupStatus.Fallido;
            }
        }

        public SetupStatus Estado => _status;

        public SetupStatus Instalar(IWin32Window owner)
        {
            if (_status == SetupStatus.Instalado)
                return _status;

            try
            {
                // Agarro siempre el token local actual.
                string everyone = new System.Security.Principal.SecurityIdentifier("S-1-1-0").Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                string sApiPort = ConfigurationManager.AppSettings["ApiPort"];
                string arguments = string.Format("http add urlacl url=http://+:{0}/ user=\"\\{1}\"", sApiPort, everyone);
                Log.Info("Agregando regla ACL...");
                ProcessHelper.RunNetShell(arguments, "Fallo al agregar la URL ACL.");
                _status = SetupStatus.Instalado;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                _status = SetupStatus.Fallido;
                MIT_NetRacer_Config.sInstancia.UrlReservationSetupHadErrors = true;
                MIT_NetRacer_Config.sInstancia.SmSave();
                throw;
            }
            return _status;
        }

        public SetupStatus Desinstalar(IWin32Window owner)
        {
            if (_status == SetupStatus.Desinstalado)
                return _status;

            SetupStatus status;
            try
            {
                string sApiPort = ConfigurationManager.AppSettings["ApiPort"];
                string arguments = $@"http delete urlacl url=http://+:{sApiPort}/";
                Log.Info("Borrando regla AC...");
                ProcessHelper.RunNetShell(arguments, "Fallo el borrado de la URL ACL");
                status = SetupStatus.Desinstalado;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                status = SetupStatus.Fallido;
            }
            return status;
        }
    }
}