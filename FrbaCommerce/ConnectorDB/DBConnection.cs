using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using FrbaCommerce.Generics;

namespace FrbaCommerce.ConnectorDB
{
    class DBConnection
    {

        private static SqlConnection persistentConnection;

        private DBConnection(string connectionString)
        {
        }

        

        public static SqlConnection getConnection
        {
            get
            {
                if (persistentConnection == null) //osea que no hay conexion
                {
                    string connectionString = AppConfigReader.Get("connection_string");
                    persistentConnection = new SqlConnection(connectionString);
                    //persistentConnection = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2014;User Id=gd;Password=gd2014");
                }
                return persistentConnection;
            }
        }
    }
}
