using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;
using System.Data.SqlClient;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.Generics;

namespace FrbaCommerce.Vistas.Abm_Rubro
{
    public partial class ListadoRubros : FormBaseListado
    {
        private RubroDB rubroDB;

        public ListadoRubros()
            : base(true)
        {
            this.rubroDB = new RubroDB();
            InitializeComponent();
            this.btn_Seleccionar.Visible = true;
            this.btn_Seleccionar.Enabled = true;
        }

        protected override void AccionIniciar()
        {
        }

        #region [AccionFiltrar]
        protected override void AccionFiltrar()
        {
            FiltroRubros filtro = new FiltroRubros();
            filtro.descripcion = tb_Descripcion.Text;

            IResultado<IList<Rubro>> resultado = this.getRubrosFiltradas(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Rubro>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;

            this.dgvBusqueda.Columns["id_rubro"].Visible = false;
        }

        private IResultado<IList<Rubro>> getRubrosFiltradas(FiltroRubros filtro)
        {
            Resultado<IList<Rubro>> resultado = new Resultado<IList<Rubro>>();
            try
            {
                resultado.Retorno = this.rubroDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }
        #endregion 

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            this.tb_Descripcion.Text = "";
        }
        #endregion
    }
}
