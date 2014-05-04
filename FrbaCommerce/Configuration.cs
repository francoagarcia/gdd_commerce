using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrbaCommerce
{
    class Configuration
    {
        private static Configuration instance;

        public static Configuration getInstance
        {
            get
            {
                return (instance == null) ? instance = new Configuration() : instance;
            }
        }

        public string getConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString"];
        }
    }
}
