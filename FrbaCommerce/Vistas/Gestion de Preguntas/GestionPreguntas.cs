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

namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    public partial class GestionPreguntas : FormBase
    {
        private Usuario usuarioActual;
        private PreguntasDB preguntasDB;
        private IList<Preguntas> preguntasPendientes;
        private IList<Preguntas> preguntaRespondidas;
        private bool ModoVerPreguntasPendientes;
        private Preguntas PreguntaSeleccionada { 
            get 
            { 
                PreguntasAMostrar pre = Seleccionar();
                Preguntas pregu = new Preguntas();
                pregu.fecha_pregunta = pre.fecha_pregunta;
                pregu.fecha_respuesta = pre.fecha_respuesta;
                pregu.id_pregunta = pre.id_pregunta;
                pregu.id_publicacion = pre.id_publicacion;
                pregu.pregunta = pre.pregunta;
                pregu.respuesta = pre.respuesta;
                pregu.usuario = new Usuario();
                pregu.usuario.username = pre.username;
                pregu.usuario.id_usuario = pre.id_usuario;
                return pregu;
            }       
        }

        public GestionPreguntas(Usuario usu)
        {
            this.preguntasDB = new PreguntasDB();
            this.usuarioActual = usu;
            InitializeComponent();
        }

        private void GestionPreguntas_Load(object sender, EventArgs e)
        {
        }

        private void btn_Ver_preguntas_pendientes_Click(object sender, EventArgs e)
        {
            this.CargarPreguntasPendientes();
        }

        private void CargarPreguntasPendientes() 
        {
            try
            {
                this.preguntasPendientes = this.preguntasDB.getPreguntasSinResponder(this.usuarioActual);
                if (this.preguntasPendientes.Count > 0)
                {
                    this.dgv_Busqueda.DataSource = this.preparaLista(this.preguntasPendientes);
                    this.PreparaGrilla();
                    this.ModoVerPreguntasPendientes = true;
                    this.btn_Seleccionar.Enabled = true;
                }
                else 
                {
                    this.dgv_Busqueda.DataSource = null;
                    this.btn_Seleccionar.Enabled = false;
                    this.dgv_Busqueda.Refresh();
                    MessageDialog.MensajeInformativo(this, "No tiene preguntas pendientes para responder!");
                }
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

        private void btn_Ver_respuestas_Click(object sender, EventArgs e)
        {
            this.CargarRespuestasHechas();
        }

        private void CargarRespuestasHechas() 
        {
            try
            {
                this.preguntaRespondidas = this.preguntasDB.getPreguntasYaRespondidas(this.usuarioActual);
                if (this.preguntaRespondidas.Count > 0)
                {
                    this.dgv_Busqueda.DataSource = this.preparaLista(this.preguntaRespondidas);
                    this.PreparaGrilla();
                    this.ModoVerPreguntasPendientes = false;
                    this.btn_Seleccionar.Enabled = true;
                }
                else 
                {
                    this.btn_Seleccionar.Enabled = false;
                    MessageDialog.MensajeInformativo(this, "No respondió ninguna pregunta aún!");
                }
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

        private void PreparaGrilla() 
        {
            this.dgv_Busqueda.Columns["id_pregunta"].HeaderText = "Id de pregunta";
            this.dgv_Busqueda.Columns["id_publicacion"].HeaderText = "Nro de publicacion";
            this.dgv_Busqueda.Columns["id_usuario"].Visible = false;
            //this.dgv_Busqueda.Columns["id_usuario"].HeaderText = "Usuario";
            this.dgv_Busqueda.Columns["fecha_pregunta"].HeaderText = "Fecha de la pregunta";
            this.dgv_Busqueda.Columns["respuesta"].HeaderText = "Respuesta";
            this.dgv_Busqueda.Columns["fecha_respuesta"].HeaderText = "Fecha de la respuesta";
            this.dgv_Busqueda.Columns["username"].HeaderText = "Nombre de usuario";
            this.dgv_Busqueda.Columns["pregunta"].HeaderText = "Pregunta";

        }

        #region [Salir]
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            Preguntas pregElegida = this.PreguntaSeleccionada;
            if (this.ModoVerPreguntasPendientes)
            {
                PreguntaRespuesta frm = new PreguntaRespuesta(pregElegida, true);
                frm.ShowDialog();
                this.CargarPreguntasPendientes();
            }
            else
            {
                PreguntaRespuesta frm = new PreguntaRespuesta(pregElegida, false);
                frm.Show();
            }
        }

        private PreguntasAMostrar Seleccionar()
        {
            object seleccionado = null;

            if (dgv_Busqueda.SelectedRows.Count > 0)
            {
                seleccionado = dgv_Busqueda.SelectedRows[0].DataBoundItem;
            }

            return seleccionado as PreguntasAMostrar;
        }

        #region Metodos privados
        private class PreguntasAMostrar
        {
            public decimal id_pregunta { get; set; }
            public decimal id_publicacion { get; set; }
            public decimal id_usuario { get; set; }
            public string username { get; set; }
            public string pregunta { get; set; }
            public DateTime fecha_pregunta { get; set; }
            public string respuesta { get; set; }
            public DateTime? fecha_respuesta { get; set; }
        }

        private IList<PreguntasAMostrar> preparaLista(IList<Preguntas> pregs)
        {

            IList<PreguntasAMostrar> pregAMostrar = new List<PreguntasAMostrar>();
            foreach (Preguntas preguntaa in pregs)
            {

                PreguntasAMostrar unaPreg = new PreguntasAMostrar();
                unaPreg.fecha_pregunta = preguntaa.fecha_pregunta;
                unaPreg.fecha_respuesta = preguntaa.fecha_respuesta;
                unaPreg.id_pregunta = preguntaa.id_pregunta;
                unaPreg.id_publicacion = preguntaa.id_publicacion;
                unaPreg.id_usuario = preguntaa.usuario.id_usuario;
                unaPreg.pregunta = preguntaa.pregunta;
                unaPreg.respuesta = preguntaa.respuesta;
                unaPreg.username = preguntaa.usuario.username;
                pregAMostrar.Add(unaPreg);
            }

            return pregAMostrar;
        }

        #endregion
    }
}
