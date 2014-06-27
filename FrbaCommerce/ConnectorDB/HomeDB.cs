using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.Generics;

namespace FrbaCommerce.ConnectorDB
{
    
    public static class HomeDB
    {
        
        public static DataSet ExecuteStoredProcedured(string comando)
        {
            return ExecuteStoredProcedured(comando, null);
        }

        public static DataSet ExecuteStoredProcedured(string comando, IList<SqlParameter> parametros)
        {

            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //ds.Tables.Add(dt);

            SqlConnection sqlConnection = DBConnection.getConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();

            //SqlConnection sqlConnection = GenerarConexion();
            //sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(comando))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                AgregarParametros(parametros, sqlCommand);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                //SqlDataReader reader = sqlCommand.ExecuteReader();
                //dt.Load(sqlCommand.ExecuteReader(CommandBehavior.CloseConnection));
                adapter.Fill(ds);
            }
            sqlConnection.Close();
            return ds;
        }

        private static SqlConnection GenerarConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(AppConfigReader.Get("connection_string"));
            return sqlConnection;
        }

        public static DataSet ExecuteStoredProceduredPaginado(int scrollVal, string comando, IList<SqlParameter> parametros)
        {

            DataSet ds = new DataSet();

            SqlConnection sqlConnection = DBConnection.getConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(comando))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                AgregarParametros(parametros, sqlCommand);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(ds, scrollVal, 5, "descripcion");
            }
            sqlConnection.Close();
            return ds;
        }


        #region Métodos privados
        private static void AgregarParametros(IList<SqlParameter> parametros, SqlCommand sqlCommand)
        {
            if (parametros != null)
            {
                foreach (SqlParameter item in parametros)
                {
                    sqlCommand.Parameters.Add(item);
                }
            }
        }
        #endregion
    }
}
