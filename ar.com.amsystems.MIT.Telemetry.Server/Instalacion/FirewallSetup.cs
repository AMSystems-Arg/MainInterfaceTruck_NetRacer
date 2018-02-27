using System;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;
using ar.com.amsystems.Telemetry.Server.Helpers;

namespace ar.com.amsystems.Telemetry.Server.Setup
{
    public class FirewallSetup : ISetup
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        static readonly string FirewallRuleName = $"MainInterfaceTelemetry_Server (PUERTO {ConfigurationManager.AppSettings["ApiPort"]})";

        SetupStatus _status;

        public FirewallSetup()
        {
            try
            {
                if (MIT_NetRacer_Config.sInstancia.FirewallSetupHadErrors)
                {
                    _status = SetupStatus.Instalado;
                }
                else
                {
                    string sPort = ConfigurationManager.AppSettings["ApiPort"];
                    const string sArg = "advfirewall firewall show rule dir=in name=all";
                    Log.Info("Chequeando regla de firewall...");
                    string output = ProcessHelper.RunNetShell(sArg, "Error al verificar regla de firewall.");
                    _status = output.Contains(sPort) && output.Contains(FirewallRuleName)
                        ? SetupStatus.Instalado : SetupStatus.Desinstalado;
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
                string sApiPort = ConfigurationManager.AppSettings["ApiPort"];
                string sArg = $"advfirewall firewall add rule name=\"{FirewallRuleName}\" " +
                                   $"dir=in action=allow protocol=TCP localport={sApiPort} remoteip=localsubnet";
                Log.Info("Agregando regla de Firewall...");
                ProcessHelper.RunNetShell(sArg, "Agregado de regla de firewall fallida.");
                _status = SetupStatus.Instalado;
            }
            catch (Exception ex)
            {
                _status = SetupStatus.Fallido;
                Log.Error(ex);
                MIT_NetRacer_Config.sInstancia.FirewallSetupHadErrors = true;
                MIT_NetRacer_Config.sInstancia.SmSave();
                throw new Exception("No se pudo configurar el Firewall de Windows." + Environment.NewLine +
                                    "Si tenes instalado otro aplicativo Firewall, por favor abri el puerto " +
                                    ConfigurationManager.AppSettings["ApiPort"] + " TCP manualmente!", ex);
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
                string arguments = $"advfirewall firewall delete rule name=\"{FirewallRuleName}\"";
                Log.Info("Borrando regla de firewall...");
                ProcessHelper.RunNetShell(arguments, "Borrado de regla de firewall fallida.");
                status = SetupStatus.Desinstalado;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                _status = SetupStatus.Fallido;
                throw new Exception("No se pudo configurar el Firewall de Windows." + Environment.NewLine +
                                    "Si tenes instalado otro aplicativo Firewall, por favor cerra el puerto " +
                                    ConfigurationManager.AppSettings["ApiPort"] + " TCP manualmente!", ex);
            }
            return status;
        }
    }
}