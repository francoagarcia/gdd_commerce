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
    public partial class FacturarPublicaciones : FormBaseAlta
    {
        private ListaFormasDePago formasDePago;
        private Usuario usuarioSeleccionado;
        private IList<ItemPendiente> items;
        private IList<VisibilidadesFacturadas> visibilidadesFacturadas;
        private FacturacionDB factuDB;

        private const string COMPRA = "COMP";
        private const string PUBLICACION = "PUBL";
        private const string BONIFICACION = "BONIF";

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
            this.CargarGrilla();
        }

        private void habilitarControllersDeFacturacion() 
        {
            this.gb_Busqueda.Enabled = true;
            this.btn_Generar.Enabled = true;
            this.btn_Limpiar.Enabled = true;
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

            // tb_Saldo.Text = "$ " + (decAcum - decTotal + decBonif).ToString();
        }

        private void CalcularTotalAdeudado() 
        {
            this.tb_Total_adeudado.Text = this.items.Sum(i => i.importe_a_rendir).ToString();
        }

        private void CargarGrilla() {
            if (itemsDB()) {
                if (this.items.Count.Equals(0))
                {
                    this.LimpiarSeleccionDeUsuario();
                    MessageDialog.MensajeInformativo(this, "El usuario elegido no tiene nada pendiente que facturar");
                }
                else 
                {
                    this.dgv_Busqueda.DataSource = this.items;
                    this.PrepararGrilla();
                    this.habilitarControllersDeFacturacion();
                    this.CalcularCostos();
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

        private void obtenerItemsBonificadosDB()
        {
            this.visibilidadesFacturadas = this.factuDB.getBonificados(this.usuarioSeleccionado);
        }

        private void obtenerItemsPendientesDeFacturarDB()
        {
            this.items = this.factuDB.getPendientesDeFacturar(this.usuarioSeleccionado);
        }

        private bool itemsDB() {
            try
            {
                this.obtenerItemsBonificadosDB();
                this.obtenerItemsPendientesDeFacturarDB();                
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

        private void dgv_Busqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(this.dgv_Busqueda.Columns["Facturar"].Index) && e.RowIndex != -1)
            {
                if (itemEsUnaBonificacion(dgv_Busqueda.Rows[e.RowIndex]))
                {
                    this.dgv_Busqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    this.dgv_Busqueda.RefreshEdit();
                }
            }
        }

        private void dgv_Busqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(this.dgv_Busqueda.Columns["Facturar"].Index) && e.RowIndex != -1)
            {
                this.dgv_Busqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)this.dgv_Busqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (itemEsUnaCompra(dgv_Busqueda.Rows[e.RowIndex]))
                {
                    if (!ValidarComprasAnteriores(this.dgv_Busqueda.Rows[e.RowIndex]))
                    {
                        this.dgv_Busqueda.Rows[e.RowIndex].Cells["Facturar"].Value = false;
                        MessageDialog.MensajeInformativo(this, "Debe pagar las compras mas antiguas primero");
                        this.dgv_Busqueda.RefreshEdit();
                    }
                }
                if (itemEsUnaBonificacion(dgv_Busqueda.Rows[e.RowIndex])) 
                {
                    this.dgv_Busqueda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    this.dgv_Busqueda.RefreshEdit();
                }

                this.Cada10PublicacionesSeDebeBonificarLaDecima(dgv_Busqueda.Rows[e.RowIndex]);

                this.CalcularCostos();
            }
        }

        private void Cada10PublicacionesSeDebeBonificarLaDecima(DataGridViewRow row) 
        {
            if (itemEsUnaPublicacion(row))
            {
                CalcularBonificacion();
            }
        }

        private bool itemMarcadoParaFacturar(DataGridViewRow row) 
        { 
            return Convert.ToBoolean(row.Cells["Facturar"].Value);
        }

        private bool itemEsUnaPublicacion(DataGridViewRow row) 
        {
            return row.Cells["tipo_item_a_facturar"].Value.ToString().Equals(PUBLICACION);
        }

        private bool itemEsUnaCompra(DataGridViewRow row)
        {
            return row.Cells["tipo_item_a_facturar"].Value.ToString().Equals(COMPRA);
        }

        private bool itemEsUnaBonificacion(DataGridViewRow row)
        {
            return row.Cells["tipo_item_a_facturar"].Value.ToString().Equals(BONIFICACION);
        }

        private decimal getIdVisibilidad(DataGridViewRow row) 
        {
            return Convert.ToDecimal(row.Cells["id_visibilidad"].Value);
        }

        private decimal getIdPublicacion(DataGridViewRow row) 
        {
            return Convert.ToDecimal(row.Cells["id_publicacion"].Value);
        }

        private decimal getImporteARendir(DataGridViewRow row) 
        {
            return Convert.ToDecimal(row.Cells["importe_a_rendir"].Value);
        }

        private DateTime getFechaInicio(DataGridViewRow row) 
        {
            return Convert.ToDateTime(row.Cells["fecha_inicio"].Value);
        }

        private bool esLaDecimaPublicacionConEsaVisibilidad(VisibilidadesFacturadas visibilidadFactu) 
        {
            return visibilidadFactu != null && ((visibilidadFactu.cantidad_marcada) % 10).Equals(0);
        }

        private ItemPendiente armarItemBonificado(DataGridViewRow row)
        {
            ItemPendiente itemBonificado = new ItemPendiente();
            itemBonificado.cantidad_a_rendir = 1;
            itemBonificado.Facturar = true;
            itemBonificado.fecha_inicio = DateManager.Ahora();
            itemBonificado.id_compra = 0;
            itemBonificado.id_publicacion = getIdPublicacion(row);
            itemBonificado.id_visibilidad = getIdVisibilidad(row);
            itemBonificado.importe_a_rendir = getImporteARendir(row);
            itemBonificado.resumen = "Bonificacion por 10 publicaciones. Publicacion bonificada: " + getIdPublicacion(row).ToString();
            itemBonificado.tipo_item_a_facturar = BONIFICACION;
            return itemBonificado;        
        }

        private void EliminarBonificaciones()
        {
            IList<ItemPendiente> itemsParaBorrar = new List<ItemPendiente>();
            foreach (ItemPendiente itm in this.items)
            {
                if (itm.tipo_item_a_facturar.Equals("BONIF"))
                {
                    ItemPendiente item = new ItemPendiente();
                    item = itm;
                    itemsParaBorrar.Add(item);
                }
            }

            if (itemsParaBorrar.Count > 0)
            {
                foreach (ItemPendiente item in itemsParaBorrar)
                {
                    this.items.Remove(item);
                }
                this.dgv_Busqueda.DataSource = null;
                this.dgv_Busqueda.DataSource = this.items;
                this.dgv_Busqueda.Refresh();
            }
            
        }

        private IList<ItemPendiente> ActualizarContadores() 
        {
            VisibilidadesFacturadas visibilidadFactu = new VisibilidadesFacturadas();
            IList<ItemPendiente> itemsBonificados = new List<ItemPendiente>();
            this.visibilidadesFacturadas.All(v => { v.cantidad_marcada = v.cantidad_fact; return true; });

            foreach (DataGridViewRow row in dgv_Busqueda.Rows)
            {
                if (itemEsUnaPublicacion(row))
                {
                    visibilidadFactu = this.visibilidadesFacturadas.Where(b => b.id_visibilidad_fact.Equals(this.getIdVisibilidad(row))).FirstOrDefault();
                    if (itemMarcadoParaFacturar(row))
                    {
                        visibilidadFactu.cantidad_marcada++;
                        if (visibilidadFactu.cantidad_marcada % 10 == 0)
                        {
                            itemsBonificados.Add(armarItemBonificado(row));
                        }
                    }
                }
            }
            return itemsBonificados;
        }

        private void CalcularBonificacion()
        {
            EliminarBonificaciones();
            IList<ItemPendiente> itemsBonificados = this.ActualizarContadores();

            if (itemsBonificados.Count > 0)
            {
                foreach (ItemPendiente itm in itemsBonificados)
                {
                    this.items.Add(itm);
                }
                this.dgv_Busqueda.DataSource = null;
                this.dgv_Busqueda.Refresh();
                this.dgv_Busqueda.DataSource = this.items;

                foreach (DataGridViewRow row in this.dgv_Busqueda.Rows)
                {
                    if (itemEsUnaBonificacion(row))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                int cant = itemsBonificados.Count;
                decimal descuentoPorBonificacio = itemsBonificados.Sum(i => i.importe_a_rendir);

                tb_Cantidad_de_bonificaciones.Text = cant.ToString();
                tb_Bonificacion_monto.Text = descuentoPorBonificacio.ToString();

                this.PrepararGrilla();
            }
            else 
            {
                tb_Cantidad_de_bonificaciones.Text = "0";
                tb_Bonificacion_monto.Text = "0";
            }
        }

        private bool ValidarComprasAnteriores(DataGridViewRow rowEvento) 
        {
            DateTime fechaDeLaCompraMarcada = getFechaInicio(rowEvento);

            if (itemMarcadoParaFacturar(rowEvento))
            {
                foreach (DataGridViewRow row in dgv_Busqueda.Rows)
                {
                    if (!itemMarcadoParaFacturar(row) && itemEsUnaCompra(row) && getFechaInicio(row) < fechaDeLaCompraMarcada)
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgv_Busqueda.Rows)
                {
                    if (itemMarcadoParaFacturar(row) && itemEsUnaCompra(row) && getFechaInicio(row) > fechaDeLaCompraMarcada) 
                    {
                        row.Cells["Facturar"].Value = false;
                        return false;
                    }
                }
            }

            return true;
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            Factura factura = this.armarFactura();
            IList<ItemFactura> items = this.armarItems();
            if (items.Count > 0)
            {
                if (this.armarFacturaDB(factura, items))
                {
                    MessageDialog.MensajeInformativo(this, "La factura fue creada exitosamente!");
                    this.CargarGrilla();
                }
            }
            else 
            {
                MessageDialog.MensajeInformativo(this, "Tiene que seleccionar los items para crear la factura!");
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
                if (itemMarcadoParaFacturar(row))
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
