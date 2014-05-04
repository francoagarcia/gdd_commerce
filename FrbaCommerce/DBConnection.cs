using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce
{
    class DBConnection
    {
        private static DBConnection instance;
        private static SqlConnection persistentConnection;

        private DBConnection(string connectionString)
        {
            persistentConnection = new SqlConnection(connectionString);
        }

        public static DBConnection getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection(Configuration.getInstance.getConnectionString());
                    //instance = new DBConnection("Data Source=UTN-GDD-DACAB4E\\SQLSERVER2008;Initial Catalog=GD1C2014;User ID=gd;Password=gd2014");
                }
                return instance;
            }
        }

        public DataTable ExecuteQuery(string procedureName, List<SqlParameter> parameters)
        {
            SqlDataAdapter adapter = null;
            try
            {
                persistentConnection.Open();
                adapter = new SqlDataAdapter(procedureName, persistentConnection);
                adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();
                adapter.Fill(data);
                return (data.Rows.Count > 0) ? data : null;
            }
            catch (Exception e)
            {
                throw new SystemException("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                if (adapter != null) adapter.SelectCommand.Connection.Close();
            }



        }
    }
}
