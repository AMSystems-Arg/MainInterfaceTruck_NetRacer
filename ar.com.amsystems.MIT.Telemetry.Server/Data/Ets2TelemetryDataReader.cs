using System;
using ar.com.amsystems.Telemetry.Server.Data.Reader;

namespace ar.com.amsystems.Telemetry.Server.Data
{
    public class Ets2TelemetryDataReader : IDisposable
    {
        /// <summary>
        /// Plugin Telemetria MIT Netracer, mapeo de data a los nombre de archivos del simulador (nombre de archivos).
        /// </summary>
        const string Ets2TelemetryMappedFileName = "Local\\Ets2TelemetryServer";

        readonly SharedProcessMemory<Ets2TelemetryStructure> _sharedMemory = 
            new SharedProcessMemory<Ets2TelemetryStructure>(Ets2TelemetryMappedFileName);

        readonly Ets2TelemetryData _data = new Ets2TelemetryData();

        readonly object _lock = new object();

        // ReSharper disable once InconsistentNaming
        static readonly Lazy<Ets2TelemetryDataReader> instance = new Lazy<Ets2TelemetryDataReader>(() => new Ets2TelemetryDataReader());
        public static Ets2TelemetryDataReader Instance => instance.Value;

        public bool IsConnected => _sharedMemory.IsConnected;

        public IEts2TelemetryData Read()
        {
            lock (_lock)
            {
                _sharedMemory.Data = default(Ets2TelemetryStructure);
                _sharedMemory.Read();
                _data.Update(_sharedMemory.Data);
                return _data;
            }
        }

        
        public void Dispose()
        {
            _sharedMemory?.Dispose();
        }
    }
}