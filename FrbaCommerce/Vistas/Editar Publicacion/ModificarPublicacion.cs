using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.Generics;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods.Validaciones;
using System.Data.SqlClient;

namespace FrbaCommerce.Vistas.Editar_Publicacion
{
    public partial class ModificarPublicacion : FormBaseModificacion
    {
        private Publicacion publiModificar;
        private PublicacionDB publiDB;
        private Usuario usuarioPublicador;
        private IList<Rubro> rubros;
        private DateTime fecha_vencimiento;
        
        public ModificarPublicacion(Publicacion publicacion, Usuario usuario)
        {
            this.fecha_vencimiento = publicacion.fecha_vencimiento;
            this.publiModificar = publicacion;
            this.usuarioPublicador = usuario;
            this.publiDB = new PublicacionDB();
            this.rubros = new RubroDB().ObtenerTodos();
            InitializeComponent();
        }

        #region [EventoLoad]
        private void ModificarPublicacion_Load(object sender, EventArgs e)
        {
            this.InhabilitarTodo();
            this.CargarCampos();
        }

        private void InhabilitarTodo() 
        {
            foreach (Control control in this.groupBox1.Controls) {
                control.Enabled = false;
            }
            this.btn_Generar.Enabled = false;
            this.btn_Limpiar.Enabled = false;
        }

        private void HabilitarTodo()
        {
            foreach (Control control in this.groupBox1.Controls)
            {
                control.Enabled = true;
            }
            this.btn_Generar.Enabled = true;
            this.btn_Limpiar.Enabled = true;
            this.groupBox1.Enabled = true;
        }

        private void HabilitacionCompraInmediata() {
            this.nud_Stock.Enabled = true;
            this.tb_Descripcion.Enabled = true;
            this.btn_Limpiar.Enabled = true;
            this.btn_Generar.Enabled = true;
            this.groupBox1.Enabled = true;
            this.lbl_Descripcion.Enabled = true;
            this.lbl_Stock.Enabled = true;
        }

        private void CargarCampos() 
        {
            ListaTipoEstados lista = new ListaTipoEstados();
            if (esCompraInmediata())
            {
                if (esPublicacionActiva())
                {
                    this.HabilitacionCompraInmediata();
                    IList<TipoEstados> estados = lista.EstadosPublicacionActiva;
                    this.cb_Estado.Enabled = true;
                    this.cb_Estado.DataSource = estados;
                    this.cb_Estado.DisplayMember = "Nombre";
                    this.cb_Estado.ValueMember = "Id";
                    this.lbl_Estado.Enabled = true;
                    this.lbl_Info_edicion.Text = "En una publicacion de compra inmediata aún activa solo se puede modificar la descripcion, el stock y estado";
                    //MessageDialog.MensajeInformativo(this, "En una publicacion de compra inmediata aún activa solo se puede modificar la descripcion, el stock y estado");
                }
                else if (esPublicacionBorrador())
                {
                    this.cb_Estado.DataSource = lista.Todos;
                    this.cb_Estado.DisplayMember = "Nombre";
                    this.cb_Estado.ValueMember = "Id";
                    this.HabilitarTodo();
                    this.lbl_Info_edicion.Text = "En una publicacion de compra inmediata en estado de borrador se pueden modificar todos los campos";
                }
                else if (esPublicacionFinalizada())
                {
                    this.cb_Estado.DataSource = lista.Todos;
                    this.lbl_Info_edicion.Text = "No se puede modificar nada de una publicacion que ya ha finalizado";
                }
                else if (esPublicacionPausada())
                {
                    this.cb_Estado.DataSource = lista.EstadosPublicacionPausada;
                    this.lbl_Info_edicion.Text = "En una publicacion de compra en estado pausado solo se puede volver a ponerla en Activo";
                    this.cb_Estado.Enabled = true;
                    this.groupBox1.Enabled = true;
                    this.btn_Generar.Enabled = true;
                }

            }
            else {
                this.cb_Estado.DataSource = lista.Todos;
                this.cb_Estado.DisplayMember = "Nombre";
                this.cb_Estado.ValueMember = "Id";
                if (esPublicacionBorrador())
                {
                    this.HabilitarTodo();
                    this.lbl_Info_edicion.Text = "En una publicacion de subasta en estado de borrador se pueden modificar todos los campos";
                }
                else
                    this.lbl_Info_edicion.Text = "Solo se puede modificar una subasta en estado borrador";
                    //MessageDialog.MensajeInformativo(this, "Solo se puede modificar una subasta en estado borrador");
            }
            this.CargarPublicacion();
        }

        private void CargarPublicacion()
        {
            this.tb_Descripcion.Text = this.publiModificar.descripcion;
            this.nud_Precio.Value = this.publiModificar.precio;
            this.nud_Stock.Value = this.publiModificar.stock;
            this.dp_Fecha_inicio.Value = this.publiModificar.fecha_inicio;
            this.tb_Fecha_de_vencimiento.Text = this.publiModificar.fecha_vencimiento.ToString();
            if(this.publiModificar.estado!=null && !this.publiModificar.estado.id_estado.Equals(3))
                this.cb_Estado.SelectedIndex = Convert.ToInt32(publiModificar.estado.id_estado)-1;
            else
                this.cb_Estado.SelectedIndex = 1;
            this.chk_Permite_preguntas.Checked = this.publiModificar.permite_preguntas;
            this.CargarListCheckBox();
            this.CargarVisibilidades();            
        }

        private void CargarListCheckBox() 
        {
            foreach (Rubro unRubro in this.rubros)
            {
                if (unRubro.descripcion != this.publiModificar.rubro.descripcion)
                    this.list_Rubros.Items.Add(unRubro.descripcion, CheckState.Unchecked);
                else
                    this.list_Rubros.Items.Add(unRubro.descripcion, CheckState.Checked);
            }

        }

        private void CargarVisibilidades() {
            IList<Visibilidad> visibilidades = (new VisibilidadDB()).ObtenerTodos();
            cb_Visibilidad.DataSource = visibilidades;
            cb_Visibilidad.DisplayMember = "descripcion";
            cb_Visibilidad.ValueMember = "id_visibilidad";
        }

        private bool esPublicacionPausada() {
            return this.publiModificar.estado.descripcion.Equals("Pausada");
        }

        private bool esPublicacionActiva() {
            return this.publiModificar.estado.descripcion.Equals("Publicada");
        }

        private bool esPublicacionBorrador() {
            return this.publiModificar.estado.descripcion.Equals("Borrador");
        }

        private bool esPublicacionFinalizada() {
            return this.publiModificar.estado.descripcion.Equals("Finalizada");
        }

        private bool esCompraInmediata() {
            return this.publiModificar.tipo_publicacion.Nombre.Equals("Compra inmediata");
        }
       
        private bool esSubasta() {
            return this.publiModificar.tipo_publicacion.Nombre.Equals("Subasta");
        } 
        #endregion
        
        #region [AccionIniciar]
        protected override void AccionIniciar()
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Descripcion, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(this.cb_Visibilidad));
            this.AgregarValidacion(new ValidadorCombobox(this.cb_Estado));
            this.AgregarValidacion(new ValidadorDateTimeUntil(this.dp_Fecha_inicio, DateManager.Ahora()));
        }
        #endregion

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            foreach (Control control in this.groupBox1.Controls) {
                if (control.Enabled)
                {
                    if(control is TextBox)
                        control.Text = "";
                    if (control is NumericUpDown)
                        ((NumericUpDown)control).Value = 0;
                    if (control is DateTimePicker)
                        ((DateTimePicker)control).Value = DateManager.Ahora();
                    if (control is ComboBox)
                        ((ComboBox)control).SelectedIndex = 0;
                    if (control is CheckedListBox)
                    {
                        for (int i = 0; i < this.list_Rubros.Items.Count; i++)
                        {
                            list_Rubros.SetItemChecked(i, false);
                        }
                    }
                }
            }
        }
        #endregion

        #region [AccionAceptar]
        protected override void AccionAceptar()
        {
            Publicacion publicacionNueva = this.armarPublicacion();
            this.AltaPublicacion(publicacionNueva);
        }

        private void AltaPublicacion(Publicacion publicacionAlta)
        {

            bool insertSalioBien = this.ModificarPublicacionDB(publicacionAlta);
            if (insertSalioBien == true)
            {
                MessageDialog.MensajeInformativo(this, "Se registro correctamente");
                this.Close();
            }
        }

        private bool ModificarPublicacionDB(Publicacion publicacion)
        {
            try
            {
                this.publiDB.modificarPublicacion(publicacion);
            }
            catch (SqlException ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;

        }

        private Publicacion armarPublicacion()
        {
            Publicacion publi = new Publicacion();
            publi.id_publicacion = this.publiModificar.id_publicacion;
            publi.usuario_publicador = this.usuarioPublicador;
            publi.descripcion = this.tb_Descripcion.Text;
            publi.fecha_inicio = this.dp_Fecha_inicio.Value;
            publi.fecha_vencimiento = this.fecha_vencimiento;
            publi.habilitada = true;
            EstadoPublicacion estado = new EstadoPublicacion();
            estado.id_estado =((TipoEstados)this.cb_Estado.SelectedItem).Id;
            estado.descripcion = ((TipoEstados)this.cb_Estado.SelectedItem).Nombre;
            publi.estado = estado;
            publi.precio = this.nud_Precio.Value;
            string rubroseleccionado = null;
            foreach (string desc in this.list_Rubros.CheckedItems)
            {
                rubroseleccionado = desc;
            }
            publi.rubro = this.rubros.Where(r => r.descripcion.Equals(rubroseleccionado)).FirstOrDefault();
            publi.stock = this.nud_Stock.Value;
            publi.tipo_publicacion = this.publiModificar.tipo_publicacion;
            publi.visibilidad = (Visibilidad)this.cb_Visibilidad.SelectedItem;
            publi.permite_preguntas = (bool)this.chk_Permite_preguntas.Checked;
            return publi;
        }
        #endregion

        #region [Cancelar]
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            this.AccionLimpiar();
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        #endregion

        private void list_Rubros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (list_Rubros.CheckedItems.Count == 1)
            {
                Boolean isCheckedItemBeingUnchecked = (e.CurrentValue == CheckState.Checked);
                if (isCheckedItemBeingUnchecked)
                {
                    e.NewValue = CheckState.Unchecked;
                }
                else
                {
                    Int32 checkedItemIndex = list_Rubros.CheckedIndices[0];
                    list_Rubros.ItemCheck -= list_Rubros_ItemCheck;
                    list_Rubros.SetItemChecked(checkedItemIndex, false);
                    list_Rubros.ItemCheck += list_Rubros_ItemCheck;
                }

                return;
            }
        }

        private void nud_Stock_ValueChanged(object sender, EventArgs e)
        {
            if (!this.esPublicacionBorrador()) {
                decimal valor = this.nud_Stock.Value;
                if (valor < this.publiModificar.stock) {
                    this.nud_Stock.Value = this.publiModificar.stock;

                }
            }
        }

        private void dp_Fecha_inicio_ValueChanged(object sender, EventArgs e)
        {
            ActualizarFechaDeVencimiento();
        }

        private void cb_Visibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFechaDeVencimiento();
        }

        private void ActualizarFechaDeVencimiento()
        {
            Visibilidad visibilidadElegida = (Visibilidad)this.cb_Visibilidad.SelectedItem;
            if (visibilidadElegida != null)
            {
                DateTime fecha_inicio = dp_Fecha_inicio.Value;
                this.fecha_vencimiento = fecha_inicio.AddDays(Convert.ToDouble(visibilidadElegida.dias_vencimiento_publi));
                this.tb_Fecha_de_vencimiento.Text = this.fecha_vencimiento.ToString();
            }
        }

    }
}
