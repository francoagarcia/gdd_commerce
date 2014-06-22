using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Abm_Visibilidad
{
    public partial class ModificarVisibilidad : FormBaseModificacion
    {

        private Visibilidad visibilidadEntidad;
        private VisibilidadDB visibilidadDB;

        public ModificarVisibilidad(Visibilidad visibilidadAModificar)
        {
            this.visibilidadEntidad = visibilidadAModificar;
            this.visibilidadDB = new VisibilidadDB();
            InitializeComponent();
        }

        #region [AccionIniciar]
        protected override void  AccionIniciar()
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Descripcion, 1, 255));
            this.AgregarValidacion(new ValidadorDecimal(this.tb_Porcentaje));
            this.AgregarValidacion(new ValidadorDecimal(this.tb_Precio));
            

            this.tb_Descripcion.Text = this.visibilidadEntidad.descripcion;
            this.tb_Porcentaje.Text = this.visibilidadEntidad.porcentaje.ToString();
            this.tb_Precio.Text = this.visibilidadEntidad.precio.ToString();
            this.nud_Dias_habilitados.Value = this.visibilidadEntidad.dias_vencimiento_publi;
        }
        #endregion

        #region [AccecionAceptar]
        protected override void AccionAceptar()
        {
            bool resultadoUpdate = this.ModificarVisibilidadDB();
            if(resultadoUpdate==true)
                base.Cancelar();
        }

        private bool ModificarVisibilidadDB()
        {
            try
            {
                this.armarVisibilidadModificada();
                this.visibilidadDB.modificarVisibilidad(this.visibilidadEntidad);
            }
            catch (SqlException exSQL)
            {
                MessageDialog.MensajeError(exSQL.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;
        }

        private void armarVisibilidadModificada()
        {
            this.visibilidadEntidad.descripcion = this.tb_Descripcion.Text;
            this.visibilidadEntidad.porcentaje = Convert.ToDecimal(this.tb_Porcentaje.Text);
            this.visibilidadEntidad.precio = Convert.ToDecimal(this.tb_Precio.Text);
            this.visibilidadEntidad.dias_vencimiento_publi = Convert.ToDecimal(this.nud_Dias_habilitados.Value);
        }
        #endregion

        #region [Cancelar]
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        #region [AccionLimpiar]
        private void btn_Limpiar_Click_1(object sender, EventArgs e)
        {
            this.AccionLimpiar();
        }

        protected override void AccionLimpiar()
        {
            this.tb_Descripcion.Text = "";
            this.tb_Porcentaje.Text = "";
            this.tb_Precio.Text = "";
        }
        #endregion 

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }



    }
}
