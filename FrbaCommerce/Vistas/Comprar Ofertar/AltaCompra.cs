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

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class AltaCompra : FormBaseAlta
    {
        //static DataRow row;
        private Usuario usuarioActual;
        private Publicacion publiCompra;
        private ComprarDB compDB;
        public Compra compra;

        public AltaCompra(Usuario usuario, Publicacion publi)
            : base("¿Esta seguro que desea realizar la compra?")
        {
            this.compDB = new ComprarDB();
            this.usuarioActual = usuario;
            this.publiCompra = publi;
            InitializeComponent();
        }

        #region [Evento Load]
        private void AltaCompra_Load(object sender, EventArgs e)
        {
            this.tb_Precio.Text = this.publiCompra.precio.ToString();
        }
        #endregion

        #region [Cancelar]
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [Comprar]
        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            bool resultado = this.ComprarDB();
            if (resultado) 
            {
                MessageDialog.MensajeInformativo(this, "La compra se ralizó con exito");
            }
        }

        private bool ComprarDB() 
        {
            try
            {
                this.compra = this.armarCompra();
                bool puedeComprar = this.compDB.nuevaCompra(this.compra);
                this.usuarioActual.habilitada_comprar = puedeComprar;
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

        private Compra armarCompra() {
            Compra compra = new Compra();
            compra.publicacion = new Publicacion();
            compra.publicacion = this.publiCompra;
            compra.usuario_comprador = new Usuario();
            compra.usuario_comprador = this.usuarioActual;
            compra.fecha = DateTime.UtcNow;
            compra.cantidad = this.nud_Ingresar_cantidad.Value;
            return compra;
        }
        #endregion

        #region [NumericUpDown Eventos]
        private void nud_Ingresar_cantidad_ValueChanged(object sender, EventArgs e)
        {
            if (this.nud_Ingresar_cantidad.Value < 1) {
                this.nud_Ingresar_cantidad.Value = 1;
            }
            if (this.nud_Ingresar_cantidad.Value > this.publiCompra.stock)
            {
                MessageDialog.MensajeError("No hay suficiente stock para comprar " + this.nud_Ingresar_cantidad.Value.ToString().Trim() + " unidades.\n Ingrese una cantidad menor o igual");
                this.nud_Ingresar_cantidad.Value = this.publiCompra.stock;
            }
        }
        #endregion
    }
}
