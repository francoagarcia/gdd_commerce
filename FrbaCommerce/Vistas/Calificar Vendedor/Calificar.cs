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
using System.Data.SqlClient;

namespace FrbaCommerce.Vistas.Calificar_Vendedor
{
    public partial class Calificar : FormBaseAlta
    {

        private Compra compraDeLaCalificacion;
        private CalificacionesDB calificacionesDB;

        public Calificar(Compra compra)
        {
            this.compraDeLaCalificacion = compra;
            this.calificacionesDB = new CalificacionesDB();
            InitializeComponent();
        }

        #region [Evento Load]

        private void Calificar_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorCombobox(cb_calificacion));
            this.AgregarValidacion(new ValidadorString(tb_comentario, 1, 255));

            this.CargarCombo();
        }

        private void CargarCombo()
        {
            List<KeyValuePair<string, int>> cb_califi = new List<KeyValuePair<string, int>>();
            cb_califi.Add(new KeyValuePair<string, int>("   ", 0));
            cb_califi.Add(new KeyValuePair<string, int>("Uno", 1));
            cb_califi.Add(new KeyValuePair<string, int>("Dos", 2));
            cb_califi.Add(new KeyValuePair<string, int>("Tres", 3));
            cb_califi.Add(new KeyValuePair<string, int>("Cuatro", 4));
            cb_califi.Add(new KeyValuePair<string, int>("Cinco", 5));
            cb_califi.Add(new KeyValuePair<string, int>("Seis", 6));
            cb_califi.Add(new KeyValuePair<string, int>("Siete", 7));
            cb_califi.Add(new KeyValuePair<string, int>("Ocho", 8));
            cb_califi.Add(new KeyValuePair<string, int>("Nueve", 9));
            cb_califi.Add(new KeyValuePair<string, int>("Diez", 10));
            this.cb_calificacion.DataSource = cb_califi;
            this.cb_calificacion.ValueMember = "Value";
            this.cb_calificacion.DisplayMember = "Key";
        }

        #endregion

        #region [AccionAceptar]
        protected override void AccionAceptar()
        {
            this.armarCalificacion();
            if (this.CalificarDB())
            {
                MessageDialog.MensajeInformativo(this, "Se calificó la compra correctamente!");
                this.Close();
            }
        }

        private bool CalificarDB()
        {
            try
            {
                decimal id_calificacion = this.calificacionesDB.nuevaCalificacion(this.compraDeLaCalificacion);
                this.compraDeLaCalificacion.calificacion.id_calificacion = id_calificacion;
            }
            catch (SqlException e)
            {
                MessageDialog.MensajeError(e.Message);
                this.Close();
                return false;
            }
            catch (Exception e)
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            return true;
        }

        private void armarCalificacion()
        {
            Calificacion calificacion = new Calificacion();
            calificacion.estrellas_calificacion = Convert.ToInt32(((KeyValuePair<string, int>)cb_calificacion.SelectedItem).Value);
            calificacion.detalle_calificacion = this.tb_comentario.Text;
            calificacion.id_calificacion = 0;

            this.compraDeLaCalificacion.calificacion = calificacion;
        }
        #endregion

        #region [Buttons]

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        #endregion


        

       
    }
}
