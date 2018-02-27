using System;
using Newtonsoft.Json; //Importamos Lib Newtonsoft para convertir a json
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ar.com.amsystems.Telemetry.Server.Helpers
{
    public static class JsonHelper
    {
        static readonly Lazy<JsonSerializerSettings> RestSettingsLazy = new Lazy<JsonSerializerSettings>(() =>
        {
            var restJsonSettings = new JsonSerializerSettings();
            restJsonSettings.Converters.Add(new StringEnumConverter());
            restJsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            restJsonSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
            return restJsonSettings;
        });

        public static readonly JsonSerializerSettings RestSettings = RestSettingsLazy.Value;
    }
}