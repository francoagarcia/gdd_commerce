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

namespace FrbaCommerce.Vistas.Calificar_Vendedor
{
    public partial class Calificar : FormBaseAlta
    {
        public Usuario usuario;
        public CalificacionesDB calificacionesDB;
        public Calificacion calificacion;
        
        public Calificar(Usuario usu)
        {
            
            this.calificacionesDB = new CalificacionesDB();
            this.calificacion = new Calificacion();
            this.usuario = usu;
            
            InitializeComponent();
        }

        
        #region [Evento Load]
        private void Calificar_Load(object sender, EventArgs e)
        {
            this.cargar_ComboCalificacion();
            this.AgregarValidacion(new ValidadorCombobox(cb_calificacion));
            this.AgregarValidacion(new ValidadorString(txt_comentario, 1, 255));

            DataSet ds = this.calificacionesDB.dame_pubsXCalificar(this.usuario);
            // cargo las publicaciones el datagridview
            gd_publicaciones.AutoGenerateColumns = true;
            gd_publicaciones.DataSource = ds.Tables[0];
        }
        
        private void cargar_ComboCalificacion(){
        
            List<KeyValuePair<string, int>> cb_califi = new List<KeyValuePair<string, int>>();
            cb_califi.Add(new KeyValuePair<string, int>("   ", 0));
     
                cb_califi.Add(new KeyValuePair<string, int>("1 - Estrella", 1));
                cb_califi.Add(new KeyValuePair<string, int>("2 - Estrellas", 2));
                cb_califi.Add(new KeyValuePair<string, int>("3 - Estrellas", 3));
                cb_califi.Add(new KeyValuePair<string, int>("4 - Estrellas", 4));
                cb_califi.Add(new KeyValuePair<string, int>("5 - Estrellas", 5));
        
            this.cb_calificacion.DataSource = cb_califi;
            this.cb_calificacion.ValueMember = "Value";
            this.cb_calificacion.DisplayMember = "Key";
        }
        
        #endregion

        #region [AccionAceptar]

        protected override void AccionAceptar()
        {
            try
            {   
                DataRowView drv = gd_publicaciones.SelectedRows[0].DataBoundItem as DataRowView;
                DataRow row = drv.Row;

                var id = row["id_compra"];
                string id_guard = id.ToString();

                //Creo el nuevo registro de calificacion 
                
                calificacionesDB.agrega_Calificaciones(calificacion);

                //El retorno, la id de calificacion, la guardo en la correspondiente compra
                calificacionesDB.actualizar_Compras(calificacion.id_calificacion, Convert.ToDecimal(id_guard));



            } catch(Exception ex){
                MessageDialog.MensajeError(ex.Message);
            }
        }
        #endregion

        #region [Cancelar]
        protected override void Cancelar()
        {
            base.Cancelar();
        }

        #endregion

        #region [Buttons]
        private void button1_Click(object sender, EventArgs e)
        {

            base.Aceptar();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }


        #endregion
    }
}
