using System.Windows.Forms;

namespace ar.com.amsystems.Telemetry.Server.Setup
{
    public interface ISetup
    {
        SetupStatus Estado { get; }
        SetupStatus Instalar(IWin32Window owner);
        SetupStatus Desinstalar(IWin32Window owner);
    }
}