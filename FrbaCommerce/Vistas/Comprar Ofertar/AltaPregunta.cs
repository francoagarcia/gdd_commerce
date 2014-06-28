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
using FrbaCommerce.Vistas.Abm_Rubro;
using FrbaCommerce.Generics;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class AltaPregunta : FormBaseAlta
    {
        private Publicacion publi;
        private PreguntasDB pregDB;
        private Usuario usuarioPreguntador;

        public AltaPregunta(Publicacion pub, Usuario usu)
        {
            this.publi = pub;
            this.usuarioPreguntador = usu;
            this.pregDB = new PreguntasDB();
            InitializeComponent();
        }

        protected override void AccionAceptar()
        {
            try
            {
                Preguntas preg = this.armarPregunta();
                this.pregDB.nuevaPreguntaEnPublicacion(preg);
            }
            catch (SqlException ex)
            {
                MessageDialog.MensajeError(ex.Message);
            }
            catch (Exception e) 
            {
                MessageDialog.MensajeError(e.Message);
            }
        }

        private Preguntas armarPregunta() 
        {
            Preguntas preg = new Preguntas();
            preg.id_pregunta = 0;
            preg.id_publicacion = this.publi.id_publicacion;
            preg.pregunta = this.tb_Pregunta.Text;
            preg.fecha_pregunta = DateManager.Ahora();
            preg.usuario = new Usuario();
            preg.usuario = this.usuarioPreguntador;
            return preg;
        }

        protected override void AccionLimpiar()
        {
            this.tb_Pregunta.Text = "";
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btn_Preguntar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        private void AltaPregunta_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion( new ValidadorString(this.tb_Pregunta, 1, 255) );
        }

    }
}
