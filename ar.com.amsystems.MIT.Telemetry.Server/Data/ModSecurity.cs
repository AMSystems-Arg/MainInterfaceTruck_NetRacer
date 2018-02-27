using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ar.com.amsystems.Telemetry.Server.Data
{
    public class ModSecurity
    {
        //SHA256 Real: 0F3FFE05632F1D9BCC772CB424C5CA3F2C564D532CA1F56EE8BC2EED51EF92E0
        const string sha256 = "0F3FFE05632F1D9BCC77"; //Los primeros 20 caracteres es el Code de Validación.

        public bool mHash256(string sHash)
        {
            bool bOk = false;
            if (sHash == sha256) { bOk = true; }
            return bOk;
        }
    }
}
