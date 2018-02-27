
using System;

namespace ar.com.amsystems.Telemetry.Server.Data.FormularioToDB
{
    public class var_dataForm
    {
        internal string s_Name, s_lastname, s_dni, s_capa;


        //MIGRAR ESTO URGENTE PARA QUE NO LLAME AL MIT por cada lectura de variable!!!!!
        //private float fKmRecorrido, fGasoilConsumo;
        //private int iInfracciones;
        
        //public float _fKmRecorrido
        //{
        //    get { return fKmRecorrido; }
        //    set
        //    {
        //        var oActualizarMit = Ets2TelemetryDataReader.Instance.Read();
        //        fKmRecorrido = (float)(Math.Round(oActualizarMit.Trayecto.f_velocimetro, 2)); //float con 2 dig.
        //    }
        //}
        //public float _fGasoilConsumo
        //{
        //    get { return fGasoilConsumo; }
        //    set
        //    {
        //        var oActualizarMit = Ets2TelemetryDataReader.Instance.Read();
        //        fGasoilConsumo = (float)(Math.Round(oActualizarMit.Trayecto.FuelAverageConsumption, 2));
        //    }
        //}
            //iInfracciones = ;

    }
}
