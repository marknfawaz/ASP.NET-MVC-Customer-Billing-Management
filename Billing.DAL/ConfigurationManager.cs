using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DAL
{
    public class ConfigurationManager
    {
        public static IConfiguration Configuration { get; set; }
    }
}
