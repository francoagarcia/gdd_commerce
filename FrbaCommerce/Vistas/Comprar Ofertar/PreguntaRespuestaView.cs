using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class PreguntaRespuestaView : Form
    {
        private Preguntas pregunta;

        public PreguntaRespuestaView(Preguntas _pregunta)
        {
            this.pregunta = _pregunta;
            InitializeComponent();
        }

        private void PreguntaRespuestaView_Load(object sender, EventArgs e)
        {
            this.CargarPregunta();
        }

        private void CargarPregunta() 
        {
            this.tb_Pregunta.Text = this.pregunta.pregunta;
            this.lbl_Pregunta.Text = this.lbl_Pregunta.Text + " ( " + this.pregunta.fecha_pregunta.ToString() +" )";
            if (this.pregunta.fecha_respuesta != null) {
                this.lbl_Respuesta.Text = this.lbl_Respuesta.Text + " ( " + this.pregunta.fecha_respuesta.ToString() + " )";
            }
            if (this.pregunta.respuesta != "")
            {
                this.tb_Respuesta.Text = this.pregunta.respuesta;
            }
            else {
                this.tb_Respuesta.Text = "Esta pregunta todavia no se ha respondido";
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
