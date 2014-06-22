using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;


namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    public partial class AltaRespuesta : FormBaseModificacion
    {
        public PreguntasDB preguntasDB;
        public Usuario usuario;
        public Preguntas pregunta;

        public AltaRespuesta(Usuario usu)
        {
            this.usuario = usu;
            this.preguntasDB = new PreguntasDB();
            this.pregunta = new Preguntas();
            InitializeComponent();
        }

        #region [AccionAceptar]
        protected override void AccionAceptar()
        {
            armarSemiPregunta();
            bool resultadoupdate = this.preguntasDB.guarda_Respuesta(pregunta);
            if (resultadoupdate == true)
                base.Cancelar();
        }

        private void armarSemiPregunta() {
            DataRowView drv = dg_preguntas.SelectedRows[0].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            var id = row["id_pregunta"];
            string id_guard = id.ToString();

            pregunta.id_pregunta = Convert.ToDecimal(id_guard);
            pregunta.respuesta = txt_respuesta.Text;
            
        }
        #endregion

        #region [EventoLoad]
        private void AltaRespuesta_Load(object sender, EventArgs e)
        {
            // Cargamos las preguntas que aun no fueron respondidas
            DataSet ds = this.preguntasDB.dame_Preguntas(this.usuario);

            dg_preguntas.AutoGenerateColumns = true;
            dg_preguntas.DataSource = ds.Tables[0];
        }
        #endregion

        #region [AccionIniciar]
        protected override void AccionIniciar()
        {
            this.AgregarValidacion(new ValidadorString(txt_respuesta, 1, 255));
        }
         #endregion

        #region [ButtonActions]
        private void btn_responder_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion



    }
}
