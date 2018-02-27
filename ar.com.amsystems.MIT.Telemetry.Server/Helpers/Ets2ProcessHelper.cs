using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using ar.com.amsystems.Telemetry.Server.Data;
using ar.com.amsystems.Telemetry.Server.Data.FormularioToDB;

namespace ar.com.amsystems.Telemetry.Server.Helpers
{
    public static class Ets2ProcessHelper
    {
        static long _lastCheckTime;
        static bool _cachedRunningFlag;

        //static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); //Log

        /// <summary>
        /// Devuelve el último nombre del Simu en ejecución: "ETS2", "ATS" o nulo si no está definido.
        /// </summary>
        public static string LastRunningGameName { get; set; }

        /// <summary>
        /// Comprueba si el proceso del juego ETS2 se está ejecutando en este momento. La frecuencia máxima de verificación está restringida a 1 segundo..
        /// </summary>
        /// <returns>True si se ejecuta el proceso ETS2, de lo contrario es false.</returns>
        public static bool IsEts2Running
        {
            get
            {
                if (DateTime.Now - new DateTime(Interlocked.Read(ref _lastCheckTime)) > TimeSpan.FromSeconds(1))
                {
                    Interlocked.Exchange(ref _lastCheckTime, DateTime.Now.Ticks);
                    var processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        try
                        {
                            bool running = process.MainWindowTitle.StartsWith("Euro Truck Simulator 2") &&
                                           process.ProcessName == "eurotrucks2"
                                           || (process.MainWindowTitle.StartsWith("American Truck Simulator") &&
                                           process.ProcessName == "amtrucks");
                            if (running)
                            {
                                _cachedRunningFlag = true;
                                LastRunningGameName = process.ProcessName == "eurotrucks2" ? "ETS2" : "ATS";
                                //Log.Info("Proceso MOD Corriendo: " + LastRunningGameName); //NO PERFORMANTE SE LO PUSO MÄS ARRIABA EN LA CLASE QUE LO LLAMA.
                                return _cachedRunningFlag;
                            }
                        }
                        // ReSharper disable once EmptyGeneralCatchClause
                        catch
                        {
                        }
                    }
                    _cachedRunningFlag = false;
                }
                return _cachedRunningFlag;
            }
        }

        public static string sEts2Version => Ets2TelemetryDataReader.Instance.Read().Mod.Version; //Migrado antes era get{}

    }
}