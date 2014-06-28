using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using System.Data.SqlClient;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Generics;

namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    public partial class PreguntaRespuesta : FormBaseAlta
    {
        private Preguntas pregunta;
        private PreguntasDB preguntaDB;
        private bool ModoCrear;

        public PreguntaRespuesta(Preguntas preg, bool modoCrear)
        {
            this.pregunta = preg;
            this.preguntaDB = new PreguntasDB();
            this.ModoCrear = modoCrear;
            InitializeComponent();
            this.ConfigurarEdicion();
        }

        private void ConfigurarEdicion() 
        {

            if (ModoCrear)
            {
                this.Text = "Responder";
                this.tb_Respuesta.ReadOnly = false;
            }
            else 
            {
                this.btn_Aceptar.Visible = false;
                this.Text = "Ver pregunta";
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void PreguntaRespuesta_Load(object sender, EventArgs e)
        {
            this.AccionIniciar();
        }

        private void AccionIniciar() {
            this.AgregarValidacion(new ValidadorString(this.tb_Respuesta, 1, 400));
            this.CargarPregunta();
        }

        private void CargarPregunta() 
        {
            this.tb_Pregunta.Text = this.pregunta.pregunta;
            this.tb_Fecha_de_pregunta.Text = this.pregunta.fecha_pregunta.ToShortDateString();
            this.tb_Usuario.Text = this.pregunta.usuario.username;
            if (this.ModoCrear)
            {
                this.tb_Respuesta.Text = "";
                this.tb_Fecha_de_respuesta.Text = DateManager.Ahora().ToString();
            }
            else 
            {
                this.tb_Respuesta.Text = this.pregunta.respuesta;
                this.tb_Fecha_de_respuesta.Text = this.pregunta.fecha_respuesta.ToString();
            }
        }

        protected override void AccionAceptar()
        {
            Preguntas preguntaNew = this.ArmarRespuesta();
            if (this.nuevaRespuestaDB(preguntaNew)) 
            {
                this.pregunta.respuesta = preguntaNew.respuesta;
                MessageDialog.MensajeInformativo(this, "La pregunta se respondió correctamente!");
                this.Close();
            }
        }

        private bool nuevaRespuestaDB(Preguntas pregunta) 
        {
            try
            {
                this.preguntaDB.nuevaRespuesta(pregunta);
            }
            catch (SqlException e)
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            catch (Exception e) 
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }

            return true;
        }
        private Preguntas ArmarRespuesta()
        {
            Preguntas preg = new Preguntas();
            preg = this.pregunta;
            preg.respuesta = this.tb_Respuesta.Text;
            return preg;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

    }
}
