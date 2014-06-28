using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.DataAccess;
using FrbaCommerce.Entidades;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics;

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class AltaOferta : FormBaseAlta
    {
        //static DataRow row;
        //static decimal precio;
        private Publicacion publi;
        private Usuario usuarioActual;
        private OfertarDB oferDB;
        public Oferta oferta;

        public AltaOferta(Publicacion _p, Usuario _u) 
            : base("¿Está seguro que desea realizar la oferta?")
        {
            this.usuarioActual = _u;
            this.publi = _p;
            this.oferDB = new OfertarDB();
            InitializeComponent();
        }

        #region [Evento Load]
        private void AltaOferta_Load(object sender, EventArgs e)
        {
            this.tb_Monto_actual.Text = this.publi.precio.ToString();
            this.nud_Ingresar_monto_a_ofertar.Value = this.publi.precio;
        }
        #endregion

        #region [Ofertar]
        private void btn_Ofertar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            bool resultado = this.OfertarDB();
            if (resultado) 
            {
                MessageDialog.MensajeInformativo(this, "La oferta se realizó con exito");
            }
        }

        private bool OfertarDB() {
            try
            {
                this.oferta = this.armarOferta();
                decimal idNuevo = this.oferDB.nuevaOferta(this.oferta);
                this.oferta.id_oferta = idNuevo;
                this.DialogResult = DialogResult.OK;
            }
            catch (SqlException e)
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;
        }

        private Oferta armarOferta()
        {
            Oferta oferta = new Oferta();
            oferta.publicacion = new Publicacion();
            oferta.publicacion = this.publi;
            oferta.usuario_ofertador = new Usuario();
            oferta.usuario_ofertador = this.usuarioActual;
            oferta.fecha = DateManager.Ahora();
            oferta.monto = this.nud_Ingresar_monto_a_ofertar.Value;
            return oferta;
        }
        #endregion

        #region [Cancelar]
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void nud_Ingresar_monto_a_ofertar_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Ingresar_monto_a_ofertar.Value < this.publi.precio) {
                this.nud_Ingresar_monto_a_ofertar.Value = this.publi.precio;
            }
        }



        //public AltaOferta(Usuario usuario, DataRowView data)
        //{

        //    InitializeComponent();
        //    DataRow row = data.Row;

        //    // consigo el precio objeto y lo transformo
        //    var st = row["precio"];
        //    string id_tipo = st.ToString();
        //    decimal precio = Convert.ToDecimal(id_tipo);

        //    InitializeComponent();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    decimal monto = Convert.ToDecimal(textBox1.Text);
        //    if (textBox1.Text != "")
        //    {
        //        // consigo el id_publicacion
        //        var st = row["id_publicacion"];
        //        string id_tipo = st.ToString();
        //        decimal id_p = Convert.ToDecimal(id_tipo);

        //        //en base al id publicacion, consigo el monto ofertado actual
        //        ComprarOfertarDB comp = new ComprarOfertarDB();
        //        DataSet ofertado = comp.get_Monto(id_p);
        //        decimal oferta = Convert.ToDecimal(ofertado.Tables[0].Rows[0][0].ToString());

        //        if ((monto > precio) || (monto > oferta))
        //        {

        //            comp.agregar_Oferta(id_p, usuarioActual.id_usuario, monto);

        //        }

        //    }

        //}
    }
}
