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
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.Generics.Resultados;

namespace FrbaCommerce.Vistas.Calificar_Vendedor
{
    public partial class SeleccionarCompra : FormBase
    {
        private Usuario usuarioActual;
        private ComprarDB compraDB;
        private IList<Compra> compras;

        public SeleccionarCompra(Usuario usu)
        {
            this.usuarioActual = usu;
            this.compraDB = new ComprarDB();
            InitializeComponent();
        }

        private void SeleccionarCompra_Load(object sender, EventArgs e)
        {
            this.CargarComprasSinCalificar();
        }

        private void CargarComprasSinCalificar() 
        {
            if (this.getComprasSinCalificarDB()) 
            {
                if (this.compras.Count > 0)
                {
                    this.dgv_Busqueda.DataSource = this.armarCompraAMostrar(this.compras);
                }
                else 
                {
                    this.dgv_Busqueda.DataSource = null;
                    this.btn_Seleccionar.Enabled = false;
                }
            }
        }

        private bool getComprasSinCalificarDB() {

            try
            {
                this.compras = this.compraDB.getComprasSinCalificar(this.usuarioActual);
            }
            catch (SqlException e)
            {
                MessageDialog.MensajeError(e.Message);
                this.Close();
                return false;
            }
            catch (Exception e) {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            return true;
        }
        
        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            Compra unaCompra = this.CompraSeleccionada;
            if (unaCompra != null)
            {
                Calificar frm = new Calificar(unaCompra);
                frm.ShowDialog(this);
                this.CargarComprasSinCalificar();
                this.dgv_Busqueda.Refresh();
                this.ValidarUsuarioHabilitadoParaComprar();
            }
        }

        private void ValidarUsuarioHabilitadoParaComprar() 
        {
            if (!this.usuarioActual.habilitada_comprar && this.compras.Count.Equals(0))
            {
                if (this.habilitarParaComprarDB()) 
                {
                    this.usuarioActual.habilitada_comprar = true;
                    MessageDialog.MensajeInformativo(this, "Ya calificó todas sus compras. Ya puede continuar comprando u ofertando!");
                    this.Close();
                }
            }
        }

        private bool habilitarParaComprarDB() 
        {
            try
            {
                this.compraDB.habilitarParaComprar(this.usuarioActual);
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

        private Compra CompraSeleccionada { get{ return Seleccionar(); } }

        private Compra Seleccionar() 
        {
            object seleccionado = null;

            if (dgv_Busqueda.SelectedRows.Count > 0)
            {
                seleccionado = dgv_Busqueda.SelectedRows[0].DataBoundItem;
            }

            CompraAMostrar compraShow= seleccionado as CompraAMostrar;
            Compra compra = this.rearmarCompra(compraShow);
            return compra;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos privados

        private Compra rearmarCompra(CompraAMostrar compra) 
        {
            Compra comp = new Compra();
            comp.calificacion = new Calificacion();
            comp.calificacion.id_calificacion = compra.id_calificacion;
            comp.calificacion.estrellas_calificacion = compra.estrellas_calificacion;
            comp.calificacion.detalle_calificacion = compra.detalle_calificacion;
            comp.fecha = compra.fecha;
            comp.id_compra = compra.id_compra;
            comp.publicacion = new Publicacion();
            comp.publicacion.id_publicacion = compra.id_publicacion;
            comp.usuario_comprador = new Usuario();
            comp.usuario_comprador.id_usuario = compra.id_usuario_comprador;
            return comp;
        }

        private IList<CompraAMostrar> armarCompraAMostrar(IList<Compra> resultado)
        {
            IList<CompraAMostrar> lista = new List<CompraAMostrar>();
            foreach (Compra comp in resultado)
            {
                CompraAMostrar compShow = new CompraAMostrar();
                compShow.cantidad = comp.cantidad;
                compShow.detalle_calificacion = comp.calificacion.detalle_calificacion;
                compShow.estrellas_calificacion = comp.calificacion.estrellas_calificacion;
                compShow.fecha = comp.fecha;
                compShow.id_calificacion = comp.calificacion.id_calificacion;
                compShow.id_compra = comp.id_compra;
                compShow.id_publicacion = comp.publicacion.id_publicacion;
                compShow.id_usuario_comprador = comp.usuario_comprador.id_usuario;
                lista.Add(compShow);
            }
            return lista;
        }

        private class CompraAMostrar
        {
            public decimal id_compra { get; set; }
            public decimal  id_publicacion { get; set; }
            public decimal id_usuario_comprador { get; set; }
            public decimal id_calificacion { get; set; }
            public decimal estrellas_calificacion { get; set; }
            public string detalle_calificacion { get; set; } 
            public DateTime? fecha { get; set; }
            public decimal cantidad;
        }
        #endregion
    }
}
