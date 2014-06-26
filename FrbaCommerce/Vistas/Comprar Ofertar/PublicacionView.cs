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
    public partial class PublicacionView : FormBase
    {
        private Publicacion publi;
        private PreguntasDB pregDB;
        private IList<Preguntas> preguntas;
        private Usuario usuarioActual;

        public PublicacionView(Publicacion pub, Usuario _usuarioActual)
        {
            this.publi = pub;
            this.pregDB = new PreguntasDB();
            this.usuarioActual = _usuarioActual;
            InitializeComponent();
        }

        #region [EventLoad]
        private void PublicacionView_Load(object sender, EventArgs e)
        {
            this.AccionIniciar();
        }

        protected void AccionIniciar() {
            this.CargarPublicacion();
            this.CargarPreguntas();
        }

        private void CargarPublicacion() {
            this.tb_Descripcion.Text = this.publi.descripcion;
            this.tb_Estado.Text = this.publi.estado.descripcion;
            this.tb_Visibilidad.Text = this.publi.visibilidad.descripcion;
            this.tb_Stock.Text = this.publi.stock.ToString();
            this.tb_Rubro.Text = this.publi.rubro.descripcion;
            this.tb_Precio.Text = this.publi.precio.ToString();
            this.tb_Fecha_de_vencimiento.Text = this.publi.fecha_vencimiento.ToString();
            if (this.publi.tipo_publicacion.Nombre.Equals("Subasta"))
            {
                this.btn_Comprar.Text = "Ofertar";
                this.lbl_Stock.Text = "Monto minimo";
            }
            if (this.publi.usuario_publicador.id_usuario == this.usuarioActual.id_usuario) 
            {
                this.btn_Comprar.Enabled = false;
                this.btn_Preguntar.Enabled = false;
            }
        }

        private void CargarPreguntas() {
            this.preguntas = pregDB.getPreguntasDeUnaPublicacion(this.publi);

            if (!this.preguntas.Count.Equals(0))
            {
                this.ClientSize = new System.Drawing.Size(683, 628);
                this.lbl_Preguntas.Text = "Seleccione una pregunta para ver su respuesta";
                this.gb_Preguntas.Visible = true;
                this.list_Preguntas.DataSource = this.preguntas;
                this.list_Preguntas.DisplayMember = "pregunta";
            }
            else 
            {
                this.ClientSize = new System.Drawing.Size(683, 384);
                this.lbl_Preguntas.Text = "No se hicieron preguntas en esta publicacion";
                this.gb_Preguntas.Visible = false;
            }
        }
        #endregion

        #region [btn_Comprar]
        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            if (this.esUnaCompraInmediata())
            {
                this.AccionComprar();
            }
            else 
            {
                this.AccionOfertar();
            }

        }

        private void AccionOfertar() {
            if (this.usuarioActual.habilitada)
            {
                AltaOferta frm = new AltaOferta(this.publi, this.usuarioActual);
                DialogResult result = frm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.publi.precio = frm.oferta.monto;
                }
                this.AccionIniciar();
            }
            else
            {
                MessageDialog.MensajeInformativo(this, "Usted no esta habilitado para realizar acciones de compra/oferta");
            }
        }

        private void AccionComprar() {
            if (this.usuarioActual.habilitada_comprar)
            {
                AltaCompra frm = new AltaCompra(this.usuarioActual, this.publi);
                DialogResult result = frm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.publi.stock = this.publi.stock - frm.compra.cantidad;
                    this.Close();
                }
                this.AccionIniciar();
            }
            else
            {
                MessageDialog.MensajeInformativo(this, "Usted no esta habilitado para realizar acciones de compra/oferta");
            }
        }

        private bool esUnaCompraInmediata() {
            return !this.publi.tipo_publicacion.Nombre.Equals("Subasta");
        }
        #endregion

        #region [Preguntar]
        private void btn_Preguntar_Click(object sender, EventArgs e)
        {
            if (this.publi.permite_preguntas)
            {
                if (this.publi.usuario_publicador.id_usuario != this.usuarioActual.id_usuario)
                {
                    AltaPregunta frm = new AltaPregunta(this.publi, this.usuarioActual);
                    frm.ShowDialog(this);
                    this.AccionIniciar();
                }
                else 
                {
                    MessageDialog.MensajeInformativo(this, "No puede realizar preguntas en su misma publicación");
                }
            }
            else 
            {
                MessageDialog.MensajeInformativo(this, "Esta publicacion no permite que se realicen preguntas");
            }
        }
        #endregion

        #region [btn_Cancelar]
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [Ver pregunta y respuesta]
        private void list_Preguntas_DoubleClick(object sender, EventArgs e)
        {
            Preguntas pregunta = this.list_Preguntas.SelectedItem as Preguntas;
            PreguntaRespuestaView frm = new PreguntaRespuestaView(pregunta);
            frm.ShowDialog(this);
        }
        #endregion



    }
}
