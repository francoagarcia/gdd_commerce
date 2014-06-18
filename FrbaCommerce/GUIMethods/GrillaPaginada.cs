using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using FrbaCommerce.DataAccess;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;
using FrbaCommerce.GUIMethods;


namespace FrbaCommerce.GUIMethods
{
    public class GrillaPaginada
    {

        private int _inicio = 0;
        private int _tope = 0;

        private int _numeroPagina = 1;
        private int _cantidadRegistros = 0;
        private int _ultimaPagina = 0;

        private String _datamember;
        private SqlDataAdapter _adapter;
        private DataSet _datos;

        //o_adapter:        Sql 
        //s_datamember:     se asigna al datagridview despues del datasource
        //i_canidadxpagina: cantidad de registros por pagina
        public GrillaPaginada(SqlDataAdapter o_adapter, DataSet oDs, DataTable oDt, String s_datamember, int i_cantidadxpagina)
        {
            this._inicio = 0;
            this._tope = i_cantidadxpagina;
            this._datamember = s_datamember;

            this._adapter = o_adapter;
            this._datos = oDs;
            this._cantidadRegistros = oDt.Rows.Count;            

            asignarTope();
        }

        private void asignarTope()
        {
            _ultimaPagina = _cantidadRegistros / _tope;

            int aux = _cantidadRegistros % _tope ;  
            if (_ultimaPagina == 0)
            {
                this._ultimaPagina = 1;
            }
            else if (_ultimaPagina >= 1 && (aux > 0))
            {
                this._ultimaPagina = _ultimaPagina + 1;
            }

            this._numeroPagina = 1;
        }

        public DataSet cargar()
        {
            return _datos;
        }

        public DataSet primeraPagina()
        {
            this._numeroPagina=1;
            this._inicio = 0;
            this._datos.Clear();
            this._adapter.Fill(this._datos, this._inicio, this._tope, this._datamember);

            return _datos;
        }
       
        public DataSet ultimaPagina() 
        {
            this._numeroPagina = _ultimaPagina;
            this._inicio = (_ultimaPagina-1 ) * _tope;
            this._datos.Clear();
            this._adapter.Fill(this._datos, this._inicio, this._tope, this._datamember);

            return _datos;
        }

        public DataSet atras()
        {
            if (this._numeroPagina == 1)
            {
                return _datos;
            }

            this._numeroPagina--;
            this._inicio = _inicio - _tope;
            this._datos.Clear();
            this._adapter.Fill(this._datos, this._inicio, this._tope, this._datamember);

            return _datos;
        }

        public DataSet adelante()
        {
            if (this._ultimaPagina == this._numeroPagina)
            {
                return _datos;
            }

            this._numeroPagina++;
            this._inicio = _inicio + _tope;
            this._datos.Clear();
            this._adapter.Fill(this._datos, this._inicio, _tope, this._datamember);

            return _datos;
        }

        public DataSet actualizaTope(int i_tope)
        {
            this._tope = i_tope;
            this._inicio = 0;
            asignarTope();

            _datos.Clear();
            this._adapter.Fill(this._datos, this._inicio, _tope, this._datamember);
            return _datos;
        }

        public int countRow()
        {
            return _cantidadRegistros;
        }

        public int countPag()
        {
            return _ultimaPagina;
        }

        public int numPag()
        {
            return _numeroPagina;
        }

        public int limitRow()
        {
            return _tope;
        }
        
    }
}
