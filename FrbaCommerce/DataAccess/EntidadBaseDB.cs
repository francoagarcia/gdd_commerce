using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Builder;
using FrbaCommerce.Generics;

namespace FrbaCommerce.DataAccess
{
    public abstract class EntidadBaseDB<T, W> : IEntidadBaseDB<T, W>
    {
        #region [Atributos]
        
        protected IBuilder<T> _builder;
        protected string _sp_filtrar;
        private string _nombreEntidad;
       
        #endregion

        #region Constructor

        public EntidadBaseDB(IBuilder<T> builder, string nombreEntidad)
        {
            _builder = builder;
            _nombreEntidad = nombreEntidad;
            GenerarNombresSP();
        }

        #endregion

        #region [Metodos ABM]

        public IList<T> Filtrar(W filtro)
        {
            //Configuro el parametro:
            IList<SqlParameter> parametros = GenerarParametrosFiltrar(filtro);

            //Ejecuto el stored procedure
            DataSet ds = HomeDB.ExecuteStoredProcedured(_sp_filtrar, parametros);

            IList<T> todos = new List<T>(ds.Tables[0].Rows.Count);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                todos.Add(this._builder.Build(fila));
            }
            return todos;
        }

        #endregion

        #region [Generadores de nombres]
       
        protected abstract IList<SqlParameter> GenerarParametrosFiltrar(W entidad);

        private void GenerarNombresSP()
        {
            string esquema = AppConfigReader.Get("BaseDeDatos_Esquema");

            _sp_filtrar = string.Format(AppConfigReader.Get("SP_Filtrar"), esquema, _nombreEntidad);
        }

        #endregion
    }
}
