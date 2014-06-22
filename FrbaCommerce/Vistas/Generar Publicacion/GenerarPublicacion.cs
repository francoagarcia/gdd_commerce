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

namespace FrbaCommerce.Vistas.Generar_Publicacion
{
    public partial class GenerarPublicacion : FormBaseAlta
    {
        private IList<Visibilidad> visibilidades;
        private IList<Rubro> rubros;
        private IList<EstadoPublicacion> estados;
        private Usuario usuarioPublicador;
        private TipoPublicacion tipoPublicacion;
        private PublicacionDB publicacionDB;
        private DateTime fecha_vencimiento;

        public GenerarPublicacion(TipoPublicacion _tipoPublicacion, Usuario _usuarioPublicador)
            : base()
        {
            this.fecha_vencimiento = new DateTime();
            this.publicacionDB = new PublicacionDB();
            this.tipoPublicacion = _tipoPublicacion;
            this.usuarioPublicador = _usuarioPublicador;
            InitializeComponent();
        }

        #region [EventLoad]
        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Descripcion, 1, 255));
            this.AgregarValidacion(new ValidadorCombobox(this.cb_Visibilidad));
            this.AgregarValidacion(new ValidadorCombobox(this.cb_Estado));
            this.AgregarValidacion(new ValidadorDateTimeUntil(this.dp_Fecha_inicio, DateManager.Ahora()));
            this.CargarCombos();
            this.CargarListaRubros();
            this.tb_Fecha_de_vencimiento.Text = "";
        }

        private void CargarCombos() {

            this.estados = (new EstadoPublicacionDB()).ObtenerTodos().Where(e => e.id_estado!=4).ToList();
            cb_Estado.DataSource = this.estados;
            cb_Estado.DisplayMember = "descripcion";
            cb_Estado.ValueMember = "id_estado";

            this.visibilidades = (new VisibilidadDB()).ObtenerTodos();
            cb_Visibilidad.DataSource = this.visibilidades;
            cb_Visibilidad.DisplayMember = "descripcion";
            cb_Visibilidad.ValueMember = "id_visibilidad";
        }

        private void CargarListaRubros() {
            this.rubros = (new RubroDB()).ObtenerTodos();
            foreach (Rubro unRubro in this.rubros) {
                this.list_Rubros.Items.Add(unRubro.descripcion, CheckState.Unchecked);
            }
        }
        #endregion

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            foreach (Control item in this.groupBox1.Controls) {
                if (item is TextBox)
                    item.Text = "";
                else if (item is NumericUpDown)
                    ((NumericUpDown)item).Value = 0;
                else if (item is DateTimePicker)
                    ((DateTimePicker)item).Value = DateManager.Ahora();
                else if (item is CheckBox)
                    ((CheckBox)item).Checked = false;
                else if (item is CheckedListBox) {
                    for (int i = 0; i < this.list_Rubros.Items.Count; i++)
                    {
                       list_Rubros.SetItemChecked(i, false);
                    }
                }
            }
            this.cb_Estado.SelectedIndex = 0;
            this.cb_Visibilidad.SelectedIndex = 0;
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

            bool insertSalioBien = this.CrearPublicacionDB(publicacionAlta);
            if (insertSalioBien == true)
            {
                MessageDialog.MensajeInformativo(this, "Se registro correctamente");
                this.Close();
            }
        }

        private bool CrearPublicacionDB(Publicacion publicacion)
        {
            try
            {
                decimal id = this.publicacionDB.nuevaPublicacion(publicacion);
                publicacion.id_publicacion = id;
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
            publi.usuario_publicador = this.usuarioPublicador;
            publi.descripcion = this.tb_Descripcion.Text;
            publi.fecha_inicio = this.dp_Fecha_inicio.Value;
            publi.fecha_vencimiento = this.fecha_vencimiento;
            publi.habilitada = true;
            publi.estado = ((EstadoPublicacion)this.cb_Estado.SelectedItem);
            publi.precio = this.nud_Precio.Value;
            publi.rubro = this.rubros.Where(r => r.descripcion.Equals(this.list_Rubros.SelectedItem)).FirstOrDefault();
            publi.stock = this.nud_Stock.Value;
            publi.tipo_publicacion = this.tipoPublicacion;
            publi.visibilidad = (Visibilidad)this.cb_Visibilidad.SelectedItem;
            publi.permite_preguntas = (bool)this.chk_Permite_preguntas.Checked;
            return publi;
        }
        #endregion

        #region [Cancelar]
        protected override void Cancelar()
        {
            base.Cancelar();
        }
        #endregion

        #region [Buttons]
        private void btn_Atras_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que volver atras? Perderá todos los datos ingresados de hacerlo.", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
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

        private void cb_Visibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActualizarFechaDeVencimiento();
        }

        private void dp_Fecha_inicio_ValueChanged(object sender, EventArgs e)
        {
            this.ActualizarFechaDeVencimiento();
        }

        private void ActualizarFechaDeVencimiento() 
        {
            Visibilidad visibilidadElegida = (Visibilidad)this.cb_Visibilidad.SelectedItem;
            DateTime fecha_inicio = dp_Fecha_inicio.Value;
            this.fecha_vencimiento = fecha_inicio.AddDays(Convert.ToDouble(visibilidadElegida.dias_vencimiento_publi));
            this.tb_Fecha_de_vencimiento.Text = this.fecha_vencimiento.ToString();
        }



    }
}
