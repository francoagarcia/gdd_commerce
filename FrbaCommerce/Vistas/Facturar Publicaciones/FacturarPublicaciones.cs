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

namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    public partial class FacturarPublicaciones : FormBaseAlta
    {
        private ListaFormasDePago formasDePago;
        private Usuario usuarioSeleccionado;
        private IList<ItemPendiente> items;
        private FacturacionDB factuDB;

        public FacturarPublicaciones()
            : base("¿Confirma la creacion de la factura?")
        {
            this.formasDePago = new ListaFormasDePago();
            this.factuDB = new FacturacionDB();
            InitializeComponent();
        }

        #region Evento Load
        private void FacturarPublicaciones_Load(object sender, EventArgs e)
        {
            this.CargarFormasDePago();
            this.AgregarValidacion(new ValidadorString(this.tb_Datos_de_pago, 1, 255));
        }

        private void CargarFormasDePago()
        {
            this.cb_Forma_pago.DataSource = this.formasDePago.Todos;
            this.cb_Forma_pago.DisplayMember = "Nombre";
            this.cb_Forma_pago.ValueMember = "Id";
        }
        #endregion

        #region Boton Cancelar
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        #region Seleccionar usuario
        private void btn_Seleccionar_usuario_Click(object sender, EventArgs e)
        {
            this.usuarioSeleccionado = null;
            using (ListadoUsuarios frm = new ListadoUsuarios())
            {
                frm.ShowDialog(this);
                this.usuarioSeleccionado = frm.EntidadSeleccionada as Usuario;
            }

            if (this.usuarioSeleccionado != null)
            {
                this.tb_Seleccionar_usuario.Text = this.usuarioSeleccionado.username;
                this.btn_Aceptar.Enabled = true;
            }
        }
        #endregion


        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.gb_Busqueda.Enabled = true;
            this.btn_Generar.Enabled = true;
            this.btn_Limpiar.Enabled = true;
            this.CargarGrilla();
            this.CalcularCostos();
        }

        private void CalcularCostos() 
        { 
            this.CalcularTotalAdeudado();
            this.CalcularTotalDeItemsAFacturar();
        }

        private void CalcularTotalDeItemsAFacturar() 
        {
            int cantidadItems = 0;
            decimal totalFacturar = 0;
            foreach (DataGridViewRow row in dgv_Busqueda.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Facturar"].Value))
                //Cuenta los que estan en true y suma los importes de ellos
                {
                    totalFacturar = totalFacturar + Convert.ToDecimal(row.Cells["importe_a_rendir"].Value);
                    cantidadItems++;
                }
            }

            this.tb_Total_a_facturar.Text = totalFacturar.ToString();
            this.tb_Cantidad_de_items.Text = cantidadItems.ToString();

            // txtSaldo.Text = "$ " + (decAcum - decTotal + decBonif).ToString();
        }

        private void CalcularTotalAdeudado() 
        {
            this.tb_Total_adeudado.Text = this.items.Sum(i => i.importe_a_rendir).ToString();
        }

        private void CargarGrilla() {
            if (itemsPendientesDB()) {
                this.dgv_Busqueda.DataSource = this.items;
                this.PrepararGrilla();
                if (this.items.Count.Equals(0)) {
                    this.btn_Generar.Enabled = this.btn_Limpiar.Enabled = false;
                }
            }
        }

        private void PrepararGrilla() 
        {
            this.dgv_Busqueda.Columns["id_publicacion"].HeaderText = "Publicacion N°";
            this.dgv_Busqueda.Columns["tipo_item_a_facturar"].HeaderText = "Tipo de item";
            this.dgv_Busqueda.Columns["resumen"].HeaderText = "Resumen";
            this.dgv_Busqueda.Columns["cantidad_a_rendir"].HeaderText = "Cantidad a rendir";
            this.dgv_Busqueda.Columns["importe_a_rendir"].HeaderText = "Importe a rendir";
            this.dgv_Busqueda.Columns["id_visibilidad"].HeaderText = "Visibilidad N°";
            this.dgv_Busqueda.Columns["id_compra"].HeaderText = "Compra N°";
            this.dgv_Busqueda.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";

            foreach (DataGridViewColumn col in this.dgv_Busqueda.Columns) {
                col.ReadOnly = true;
            }
            this.dgv_Busqueda.Columns["Facturar"].ReadOnly = false;
        }

        private bool itemsPendientesDB() {
            try
            {
                this.items = this.factuDB.getPendientesDeFacturar(this.usuarioSeleccionado);
            }
            catch (Exception e)
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            return true;
        }

        private void btn_Limpiar_usuario_seleccion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea limpiar los campos?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.LimpiarSeleccionDeUsuario();
            }
        }

        private void LimpiarSeleccionDeUsuario()
        {
            this.tb_Seleccionar_usuario.Text = "";
            this.LimpiarDatosFactura();
            this.gb_Busqueda.Enabled = false;
            this.btn_Generar.Enabled = false;
            this.btn_Limpiar.Enabled = false;
            this.dgv_Busqueda.DataSource = null;
            this.usuarioSeleccionado = null;
            this.btn_Aceptar.Enabled = false;
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }

        protected override void AccionLimpiar()
        {
            this.LimpiarDatosFactura();
            this.LimpiarGrilla();
            this.CalcularCostos();
        }

        private void LimpiarDatosFactura() 
        {
            this.tb_Bonificacion_monto.Text = "";
            this.tb_Cantidad_de_bonificaciones.Text = "";
            this.tb_Cantidad_de_items.Text = "";
            this.tb_Datos_de_pago.Text = "";
            this.tb_Total_a_facturar.Text = "";
            this.tb_Total_adeudado.Text = "";
        }

        private void LimpiarGrilla() {
            foreach (DataGridViewRow row in dgv_Busqueda.Rows)
            {
                row.Cells["Facturar"].Value = false;
            }
        }

        private void dgv_Busqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(this.dgv_Busqueda.Columns["Facturar"].Index) && e.RowIndex!=-1)
            {
                this.dgv_Busqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)this.dgv_Busqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                this.CalcularCostos();
            }
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            Factura factura = this.armarFactura();
            IList<ItemFactura> items = this.armarItems();
            if (this.armarFacturaDB(factura, items))
            {
                MessageDialog.MensajeInformativo(this, "La factura fue creada exitosamente!");
                this.CargarGrilla();
            }
        }

        private bool armarFacturaDB(Factura factura, IList<ItemFactura> items)
        {
            try
            {
                decimal nro_factura = this.factuDB.CrearFacturaCompleta(factura, items);
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

        private Factura armarFactura() 
        {
            Factura factura = new Factura();
            factura.vendedor = this.usuarioSeleccionado;
            factura.forma_pago = this.cb_Forma_pago.SelectedItem as FormaDePago;
            factura.forma_pago_datos = this.tb_Datos_de_pago.Text;
            factura.total = Convert.ToDecimal(this.tb_Total_a_facturar.Text);
            return factura;
        }

        private IList<ItemFactura> armarItems()
        {
            IList<ItemFactura> items = new List<ItemFactura>();
            foreach (DataGridViewRow row in dgv_Busqueda.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Facturar"].Value))
                {
                    items.Add(armarUnItem(row));
                }
            }
            return items;
        }

        private ItemFactura armarUnItem(DataGridViewRow row) 
        {
            ItemFactura item = new ItemFactura();
            item.id_publicacion = Convert.ToDecimal(row.Cells["id_publicacion"].Value);
            item.id_compra = Convert.ToDecimal(row.Cells["id_compra"].Value);
            item.resumen = Convert.ToString(row.Cells["resumen"].Value);
            item.cantidad = Convert.ToDecimal(row.Cells["cantidad_a_rendir"].Value);
            item.monto = Convert.ToDecimal(row.Cells["importe_a_rendir"].Value);
            item.nro_factura = 0;
            return item;
        }
    }
}
