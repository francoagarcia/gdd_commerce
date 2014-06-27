using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using System.Data.SqlClient;
using FrbaCommerce.Generics;

namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    public partial class FacturaVista : Form
    {
        private Factura factura;
        private IList<ItemFactura> items;

        private const string COMPRA = "COMP";
        private const string PUBLICACION = "PUBL";
        private const string BONIFICACION = "BONIF";

        public FacturaVista(Factura _factura, IList<ItemFactura> _items)
        {
            this.factura = _factura;
            this.items = _items;
            InitializeComponent();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturaVista_Load(object sender, EventArgs e)
        {
            this.CargarFactura();
        }

        private void CargarFactura() 
        {
            this.tb_Username.Text = this.factura.vendedor.username;
            this.tb_Total_facturado.Text = "$ "+this.factura.total.ToString();
            this.tb_Fecha.Text = DateTime.UtcNow.ToString();
            this.lbl_Titulo.Text = this.lbl_Titulo.Text + this.factura.nro_factura.ToString();
            this.CargarItems();
        }

        private void CargarItems() 
        {
            this.list_Items.DataSource = this.items;
            this.list_Items.DisplayMember = "resumen";
        }
    }
}
