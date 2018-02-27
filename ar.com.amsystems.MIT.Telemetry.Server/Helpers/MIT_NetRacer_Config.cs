using System;
using System.IO;
using System.Text;
using Newtonsoft.Json; //Importamos Lib Newtonsoft para convertir a json

namespace ar.com.amsystems.Telemetry.Server.Helpers
{
    public class MIT_NetRacer_Config
    {
        #region Settings

        public string DefaultNetworkInterfaceId { get; set; }
        public string Ets2GamePath { get; set; }
        public string AtsGamePath { get; set; }

        public bool FirewallSetupHadErrors { get; set; }
        public bool UrlReservationSetupHadErrors { get; set; }

        #endregion

        const string ApplicationName = "MainInterfaceTruckServer" +
            ""; //"ETS2-ATS Telemetry Server";
        const string sArchivoJson = "MIT_NetRacer_Config.json"; //Settings.json

        public static readonly string ssSettingsDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationName);
        static readonly string ssSettingsFileName = Path.Combine(ssSettingsDirectory, sArchivoJson);

        public static void Clear()
        {
            //Borrado de archivos y directorio setup.
            if (File.Exists(ssSettingsFileName))
                File.Delete(ssSettingsFileName);
            if (Directory.Exists(ssSettingsDirectory))
                Directory.Delete(ssSettingsDirectory);
        }

        static MIT_NetRacer_Config SmLoad()
        {
            if (!File.Exists(ssSettingsFileName)) return new MIT_NetRacer_Config();

            return JsonConvert.DeserializeObject<MIT_NetRacer_Config>(File.ReadAllText(ssSettingsFileName, Encoding.UTF8));
        }

        public void SmSave()
        {
            if (!Directory.Exists(ssSettingsDirectory)) Directory.CreateDirectory(ssSettingsDirectory);

            File.WriteAllText(ssSettingsFileName, JsonConvert.SerializeObject(this, Formatting.Indented), Encoding.UTF8);
        }

        static readonly Lazy<MIT_NetRacer_Config> LazyInstance = new Lazy<MIT_NetRacer_Config>(SmLoad);
        public static readonly MIT_NetRacer_Config sInstancia = LazyInstance.Value;
    }
}