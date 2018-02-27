using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using ar.com.amsystems.Telemetry.Server.Helpers;
using Microsoft.Win32;

namespace ar.com.amsystems.Telemetry.Server.Setup
{
    public class SetupPlugin : ISetup
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        const string sETS2 = "ETS2";
        //const string sATS = "ATS";
        SetupStatus i_status;
        
        public SetupPlugin()
        {
            try
            {
                Log.Info("Verificando archivo plugin DLL...");
                
                var estadoETS2 = new GameState(sETS2, MIT_NetRacer_Config.sInstancia.Ets2GamePath);
                //var estadoATS = new GameState(sATS, MIT_NetRacer_Config.sInstancia.AtsGamePath);

                if (estadoETS2.IsPluginValid())// && estadoATS.IsPluginValid())
                {
                    //Llamo interface de estado
                    i_status = SetupStatus.Instalado;
                }
                else
                {
                    //Llamo interface de estado
                    i_status = SetupStatus.Desinstalado;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                //Llamo interface de estado
                i_status = SetupStatus.Fallido;
            }
        }

        public SetupStatus Estado => i_status;

        public SetupStatus Instalar(IWin32Window owner)
        {
            if (i_status == SetupStatus.Instalado)
                return i_status; //PlugIn Instaldo Correctamente.

            try
            {
                var EstadoETS2 = new GameState(sETS2, MIT_NetRacer_Config.sInstancia.Ets2GamePath);
                //var EstadoATS = new GameState(sATS, MIT_NetRacer_Config.sInstancia.AtsGamePath);

                if (!EstadoETS2.IsPluginValid())
                {
                    EstadoETS2.DetectPath();
                    if (!EstadoETS2.IsPathValid())
                        EstadoETS2.BrowserForValidPath(owner);
                    EstadoETS2.InstalarPlugIn();
                }

                //Para MOD AmericanTruckSimulador
                //if (!EstadoATS.IsPluginValid())
                //{
                //    EstadoATS.DetectPath();
                //    if (!EstadoATS.IsPathValid())
                //        EstadoATS.BrowserForValidPath(owner);
                //    EstadoATS.InstallPlugin();
                //}
                
                MIT_NetRacer_Config.sInstancia.Ets2GamePath = EstadoETS2.RutaMod;
                //MIT_NetRacer_Config.sInstancia.AtsGamePath = EstadoATS.GamePath;
                MIT_NetRacer_Config.sInstancia.SmSave();
                
                i_status = SetupStatus.Instalado;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                i_status = SetupStatus.Fallido;
                throw;
            }
            
            return i_status;
        }

        public SetupStatus Desinstalar(IWin32Window owner)
        {
            if (i_status == SetupStatus.Desinstalado)
                return i_status; //PlugIns Desistalado correctamente.

            SetupStatus status;
            try
            {
                var EstadoETS2 = new GameState(sETS2, MIT_NetRacer_Config.sInstancia.Ets2GamePath);
                //var EstadoATS = new GameState(sATS, MIT_NetRacer_Config.sInstancia.AtsGamePath);
                EstadoETS2.DesinstalarPlugIn();
                //EstadoATS.UninstallPlugin();
                status = SetupStatus.Desinstalado;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                status = SetupStatus.Fallido;
            }
            return status;
        }
        
        class GameState
        {
            const string InstallationSkippedPath = "N/A";
            const string TelemetryDllNameETS2 = "MIT_NetRacer-lib-ETS2.dll";
            const string TelemetryX64DllMd5 = "aeffffe2e6c3c4fd6ef1ad1eb44171cd";
            const string TelemetryX86DllMd5 = "ab473bea2dd9480e249133ec908e8252";

            readonly string _sNombreMod;

            public GameState(string sNombreMod, string sRutaMod)
            {
                _sNombreMod = sNombreMod;
                RutaMod = sRutaMod;
            }

            string SNombreDireMod
            {
                get
                {
                    string fullName = "Euro Truck Simulator 2";
                    //Para MOD AmericanTruckSimulador
                    //if (_sNombreMod == sATS) fullName = "American Truck Simulator";
                    return fullName;
                }
            }

            public string RutaMod { get; private set; }

            public bool IsPathValid()
            {
                if (RutaMod == InstallationSkippedPath)
                    return true;

                if (string.IsNullOrEmpty(RutaMod))
                    return false;

                var baseScsPath = Path.Combine(RutaMod, "base.scs");
                var binPath = Path.Combine(RutaMod, "bin");
                bool validated = File.Exists(baseScsPath) && Directory.Exists(binPath);
                Log.InfoFormat("Validando {2} Ruta: '{0}' ... {1}", RutaMod, validated ? "OK" : "NOOK", _sNombreMod);
                return validated;
            }

            public bool IsPluginValid()
            {
                if (RutaMod == InstallationSkippedPath)
                    return true;

                if (!IsPathValid())
                    return false;

                return Md5(GetTelemetryPluginDllFileName(RutaMod, x64: true)) == TelemetryX64DllMd5 && Md5(GetTelemetryPluginDllFileName(RutaMod, x64: false)) == TelemetryX86DllMd5;
            }

            public void InstalarPlugIn()
            {
                if (RutaMod == InstallationSkippedPath)
                    return;

                string x64DllFileName = GetTelemetryPluginDllFileName(RutaMod, x64: true);
                string x86DllFileName = GetTelemetryPluginDllFileName(RutaMod, x64: false);

                Log.InfoFormat("Copiando plugin DLL x86 {1} en: {0}", x86DllFileName, _sNombreMod);
                File.Copy(LocalEts2X86TelemetryPluginDllFileName, x86DllFileName, true);

                Log.InfoFormat("Copiando plugin DLL x64 {1} en: {0}", x64DllFileName, _sNombreMod);
                File.Copy(LocalEts2X64TelemetryPluginDllFileName, x64DllFileName, true);
            }

            public void DesinstalarPlugIn()
            {
                if (RutaMod == InstallationSkippedPath)
                    return;

                Log.InfoFormat("Backup del plugin DLL del archivo {0}...", _sNombreMod);
                string x64DllFileName = GetTelemetryPluginDllFileName(RutaMod, x64: true);
                string x86DllFileName = GetTelemetryPluginDllFileName(RutaMod, x64: false);
                string x86BakFileName = Path.ChangeExtension(x86DllFileName, ".bak");
                string x64BakFileName = Path.ChangeExtension(x64DllFileName, ".bak");
                if (File.Exists(x86BakFileName))
                    File.Delete(x86BakFileName);
                if (File.Exists(x64BakFileName))
                    File.Delete(x64BakFileName);
                File.Move(x86DllFileName, x86BakFileName);
                File.Move(x64DllFileName, x64BakFileName);
            }

            //Verifico en la Registry de Windows la ruta de MOD de STEAM
            static string GetDefaultSteamPath()
            {
                var steamKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");
                return steamKey?.GetValue("SteamPath") as string;
            }

            static string LocalEts2X86TelemetryPluginDllFileName => Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"MIT_NetRacer-Plugins\win_x86\", TelemetryDllNameETS2);

            static string LocalEts2X64TelemetryPluginDllFileName => Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"MIT_NetRacer-Plugins\win_x64\", TelemetryDllNameETS2);
            
            static string GetPluginPathMod(string sRutaMod, bool x64)
            {
                return Path.Combine(sRutaMod, x64 ? ConfigurationManager.AppSettings["RutaPlugins_ETS2_x64"] : ConfigurationManager.AppSettings["RutaPlugins_ETS2_x86"]);
            }

            static string GetTelemetryPluginDllFileName(string gamePath, bool x64)
            {
                string path = GetPluginPathMod(gamePath, x64);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return Path.Combine(path, TelemetryDllNameETS2);
            }
            
            static string Md5(string fileName)
            {
                if (!File.Exists(fileName))
                    return null;
                using (var provider = new MD5CryptoServiceProvider())
                {
                    var bytes = File.ReadAllBytes(fileName);
                    var hash = provider.ComputeHash(bytes);
                    var result = string.Concat(hash.Select(b => $"{b:x02}"));
                    return result;
                }
            }

            public void DetectPath()
            {
                RutaMod = GetDefaultSteamPath();
                if (!string.IsNullOrEmpty(RutaMod))
                    RutaMod = Path.Combine(
                        RutaMod.Replace('/', '\\'), @"SteamApps\common\" + SNombreDireMod);
            }

            public void BrowserForValidPath(IWin32Window owner)
            {
                while (!IsPathValid())
                {
                    var result = MessageBox.Show(owner,
                        @"No se pudo encontrar la ruta del Mod " + _sNombreMod + ". " +
                        @"Si no lo tenes instalado desde STEAM presiona [Cancelar] " + 
                        @"caso contrario presiona [Aceptar] para buscar la ruta manualmente." + Environment.NewLine + Environment.NewLine +
                        @"Por ejemplo:" + Environment.NewLine + @"D:\STEAM\SteamApps\common\" + SNombreDireMod,
                        @"Problemas en la Instalación", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Cancel)
                    {
                        RutaMod = InstallationSkippedPath;
                        return;
                    }
                    var browser = new FolderBrowserDialog();
                    browser.Description = @"Seleccione la ruta del Mod " + _sNombreMod;
                    browser.ShowNewFolderButton = false;
                    result = browser.ShowDialog(owner);
                    if (result == DialogResult.Cancel)
                        Environment.Exit(1);
                    RutaMod = browser.SelectedPath;
                }
            }
        }
    }
}