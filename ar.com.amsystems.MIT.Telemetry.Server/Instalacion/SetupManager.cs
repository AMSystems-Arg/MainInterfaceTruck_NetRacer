namespace ar.com.amsystems.Telemetry.Server.Setup
{
    public static class Instalador
    {
        public static ISetup[] Procedimiento;

        static Instalador()
        {
            Procedimiento = new ISetup[]
            {
                // Verificamos e instalamos el PlugIns del MOD.
                    new SetupPlugin(),
                // Configuramos Regla de Firewall. 
                    new FirewallSetup(), 
                // Listamos la URL API.
                    new UrlReservationSetup()
            };
        }
    }
}