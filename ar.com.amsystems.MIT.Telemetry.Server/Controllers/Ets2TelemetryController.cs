using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web.Http;
using ar.com.amsystems.Telemetry.Server.Data;
using ar.com.amsystems.Telemetry.Server.Helpers;
using Newtonsoft.Json;

namespace ar.com.amsystems.Telemetry.Server.Controllers
{
   
    [RoutePrefix("api-internal")]
    public class Ets2TelemetryController : ApiController
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public const string TelemetryApiUriPath = "/api-internal/mit-netracer/reporte";
        const string TestTelemetryJsonFileName = "MIT_NetRacerPruebaTelemetria.json";

        static readonly bool UseTestTelemetryData = Convert.ToBoolean(ConfigurationManager.AppSettings["MIT_NetRacerPruebaTelemetria"]);

        public static string GetEts2TelemetryJson()
        {
            // Si tengo datos de prueba json, definirlo en el app.config antes de usarlo.
            if (UseTestTelemetryData)
            {
                try
                {
                    using (var file = File.Open(
                            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestTelemetryJsonFileName),
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite))
                    using (var reader = new StreamReader(file, Encoding.UTF8))
                        return reader.ReadToEnd();
                }
                catch (Exception er)
                {
                    Log.Error("Error en plugins modulo TelemetryData, detalle " + er.ToString());
                }
            }

            // Sobreescribe los datos real de retorno desde el simulador.
            return JsonConvert.SerializeObject(Ets2TelemetryDataReader.Instance.Read(), JsonHelper.RestSettings); //Llamo mediante sharedmemory los datos del mod en Read().
        }
        
        //MENSAJERIA JSON MEDIANTE APIS REST con WEBSOCKET 
        [HttpGet]
        [HttpPost]
        [Route("mit-netracer/reporte", Name = "Get")] //[Route("ets2/telemetry", Name = "Get")]
        public HttpResponseMessage Get()
        {
            var otelemetryJson = GetEts2TelemetryJson();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(otelemetryJson, Encoding.UTF8, "application/json");
            response.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true };    
            return response;
        }
    }
}