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

namespace FrbaCommerce.Vistas.Abm_Visibilidad
{
    public partial class ListadoVisibilidad : FormBaseListado
    {
        #region [Atributos]
        private VisibilidadDB visibilidadDB;
        #endregion 

        #region [Constructores]
        public ListadoVisibilidad(bool modoSeleccion) :base(modoSeleccion)
        {
            this.visibilidadDB = new VisibilidadDB();
            InitializeComponent();
        }

        public ListadoVisibilidad() : this(false)
        {
        }
        #endregion

        #region [AccionAlta]
        protected override void AccionAlta()
        {
            AltaVisibilidad altaVis = new AltaVisibilidad();
            altaVis.ShowDialog();
        }
        #endregion

        #region [AccionModificar]
        protected override void AccionModificar()
        {
            Visibilidad seleccionado = this.EntidadSeleccionada as Visibilidad;
            using (ModificarVisibilidad frm = new ModificarVisibilidad(seleccionado))
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [AccionBorrar]
        protected override void AccionBorrar()
        {
            Visibilidad seleccionado = this.EntidadSeleccionada as Visibilidad;
            this.habilitacionDelRegistro(seleccionado);
            this.Filtrar();
        }

        private void habilitacionDelRegistro(Visibilidad visibilidad) {
            try
            {
                if (visibilidad.habilitada)
                {
                    this.visibilidadDB.inHabilitarVisibilidad(visibilidad);

                    visibilidad.habilitada = false;
                }
                else
                {
                    this.visibilidadDB.habilitarVisibilidad(visibilidad);
                    visibilidad.habilitada = true;
                }
            }
            catch (SqlException exSQL)
            {
                MessageDialog.MensajeError(exSQL.Message);
            }
            catch (Exception ex) 
            {
                MessageDialog.MensajeError(ex.Message);
            }
        }
        #endregion

        #region [AccionFiltrar]
        protected override void AccionFiltrar()
        {
            FiltroVisibilidades filtro = new FiltroVisibilidades();
            filtro.Nombre = tb_Nombre_de_visibilidad.Text;
            if (!string.IsNullOrEmpty(tb_Precio.Text))
                filtro.Precio = Convert.ToDecimal(tb_Precio.Text);

            if (!string.IsNullOrEmpty(tb_Porcentaje.Text))
                filtro.Porcentaje = Convert.ToDecimal(tb_Porcentaje.Text);

            IResultado<IList<Visibilidad>> resultado = this.getVisibilidadesFiltradas(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Visibilidad>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;

            this.PrepararGrilla();
            //this.dgvBusqueda.Columns["id_visibilidad"].Visible = false;
            //this.dgvBusqueda.Columns["habilitada"].Visible = false;
        }

        private void PrepararGrilla() 
        {
            this.dgvBusqueda.Columns["id_visibilidad"].HeaderText = "Nro de visibilidad";
            this.dgvBusqueda.Columns["habilitada"].HeaderText = "Habilitada";
            this.dgvBusqueda.Columns["precio"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["porcentaje"].HeaderText = "Porcentj";
            this.dgvBusqueda.Columns["dias_vencimiento_publi"].HeaderText = "Habilitada";
        }

        private IResultado<IList<Visibilidad>> getVisibilidadesFiltradas(FiltroVisibilidades filtro)
        {
            Resultado<IList<Visibilidad>> resultado = new Resultado<IList<Visibilidad>>();
            try
            {
                resultado.Retorno = this.visibilidadDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }
        #endregion

        #region [Accion Iniciar]
        protected override void AccionIniciar()
        {
            this.AccionLimpiar();
        }
        #endregion

        #region [Accion Limpiar Campos]
        protected override void AccionLimpiar()
        {
            this.tb_Nombre_de_visibilidad.Text = "";
            this.tb_Porcentaje.Text = "";
            this.tb_Precio.Text = "";
        }
        #endregion

    }
}
