using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrbaCommerce.Generics
{
    public static class AppConfigReader
    {
        public static string Get(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
