using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Entidades;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.Vistas.Abm_Visibilidad
{
    public partial class AltaVisibilidad : FormBaseAlta
    {
        VisibilidadDB visibilidadDB;

        public AltaVisibilidad()
        {
            InitializeComponent();
            this.visibilidadDB = new VisibilidadDB();
        }

        public AltaVisibilidad(VisibilidadDB _visibilidadDB)
        {
            InitializeComponent();
            this.visibilidadDB = _visibilidadDB;
        }

        #region [Evento Load]
        private void AltaVisibilidad_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorNumerico(this.tb_Porcentaje));
            this.AgregarValidacion(new ValidadorNumerico(this.tb_Precio));
            this.AgregarValidacion(new ValidadorString(this.tb_Descripcion, 1, 255));
        }
        #endregion

        #region [AccionCancelar]
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        #region [AccionAceptar]
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        protected override void AccionAceptar()
        {
            try
            {
                Visibilidad visi = this.armarVisibilidad();
                decimal idNuevoVisibilidad = this.visibilidadDB.crearVisibilidad(visi);
                visi.IdVisibilidad = idNuevoVisibilidad;
            } catch(Exception ex){
                MessageDialog.MensajeError(ex.Message);
            }
        }

        private Visibilidad armarVisibilidad() {
            Visibilidad visi = new Visibilidad();
            visi.Descripcion = tb_Descripcion.Text;
            visi.Porcentaje = Convert.ToDecimal(tb_Porcentaje.Text);
            visi.Precio = Convert.ToDecimal(tb_Precio.Text);
            visi.IdVisibilidad = 0;
            visi.Habilitada = true;
            return visi;
        }
        #endregion

    }
}
