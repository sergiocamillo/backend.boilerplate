using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smc.Services.Api.Configurations
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
