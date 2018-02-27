using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;

namespace ar.com.amsystems.Telemetry.Server.Helpers
{
    public static class NetworkHelper
    {
        static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static NetworkInterfaceInfo[] GetAllActiveNetworkInterfaces()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();

            Log.InfoFormat("Se encontraron las siguientes interfaces de red: {0}{1}", Environment.NewLine,
                string.Join(", " + Environment.NewLine,
                    interfaces.Select(a => $"'{a.Id}': '{a.Name}' ({a.OperationalStatus})")));

            var foundInterfaces = interfaces.Where(
                    a => a.OperationalStatus.ToString() == "Up" &&
                    a.GetIPProperties()
                     .UnicastAddresses.Any(ua => ua.Address.AddressFamily == AddressFamily.InterNetwork))
                     .Select(i => new NetworkInterfaceInfo
                     {
                         Id = i.Id,
                         Name = i.Name,
                         Ip = i.GetIPProperties().UnicastAddresses
                            .First(ua => ua.Address.AddressFamily == AddressFamily.InterNetwork).Address.ToString()
                     }).ToArray();

            if (!foundInterfaces.Any())
                throw new Exception(
                    "El sistema no tiene ninguna interfaz de red registrada que esté conectada a una red.");

            return foundInterfaces;
        }
    }

    public class NetworkInterfaceInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}