using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.FormBase
{
    public partial class FormBaseListado : FormBase
    {
         public FormBaseListado(bool modoSeleccion)
            :base()
        {
            InitializeComponent();
            ModoSeleccion = modoSeleccion;
        }

         public FormBaseListado()
            :this(false)
        {
            
        }

        /// <summary>
        /// Permite indicar si se retornara un objeto de la grilla al salir
        /// del formulario.
        /// </summary>
        /// 
        public bool ModoSeleccion { get; set; }
        public object EntidadSeleccionada { get { return Seleccionar(); } }

        #region [FormularioBaseListado_Load]
        private void FormularioBaseListado_Load(object sender, EventArgs e)
        {
            this.btn_Seleccionar.Visible = ModoSeleccion;
            this.btnAlta.Visible = !ModoSeleccion;
            this.btnModificacion.Visible = !ModoSeleccion;
            this.btn_Habilitacion.Visible = !ModoSeleccion;

            this.AccionIniciar();
            this.Filtrar();
        }

        protected virtual void AccionIniciar()
        {

        }
        #endregion

        #region [btnLimpiar]
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea limpiar los campos?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.AccionLimpiar();
                this.Filtrar();
            }
        }

        protected virtual void AccionLimpiar()
        {
            throw new NotImplementedException("Implementar acción del botón Limpiar");
        }
        #endregion

        #region [btnFiltrar]
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }
        protected virtual void Filtrar()
        {
            if (base.Validar())
            {
                this.AccionFiltrar();
            }
        }


        protected virtual void AccionFiltrar()
        {
        }
        #endregion

        #region [btnAlta]
        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.AccionAlta();
            this.Filtrar();
        }
        protected virtual void AccionAlta()
        {
            throw new NotImplementedException("Implementar acción del botón Alta");
        }
        #endregion

        #region [btnModificacion]
        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (this.EntidadSeleccionada == null)
            {
                MessageDialog.MensajeError(this, "Debe seleccionar un registro primero");
            }
            else
            {
                this.AccionModificar();
                this.Filtrar();
            }
        }
        protected virtual void AccionModificar()
        {
            throw new NotImplementedException("Implementar acción del botón Modificar");
        }
        #endregion

        #region [btnBaja]
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.EntidadSeleccionada == null)
            {
                MessageDialog.MensajeError(this, "Debe seleccionar un registro primero");
            }
            else
            {
                DialogResult dr = MessageDialog.MensajeInformativo(this, "¿Está seguro que quiere hacer eso?", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    this.AccionBorrar();
                    this.Filtrar();
                }
            }
        }
        protected virtual void AccionBorrar()
        {
            //throw new NotImplementedException("Implementar acción del botón Borrar");
        }
        #endregion

        #region [btnSeleccionar]
        protected virtual object Seleccionar()
        {
            object seleccionado = null;

            if (dgvBusqueda.SelectedRows.Count > 0)
            {
                seleccionado = dgvBusqueda.SelectedRows[0].DataBoundItem;
            }

            return seleccionado;
        }

        private void AgregarBotonSeleccionar()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dgvBusqueda.Columns.Add(buttonColumn);
        }

        protected virtual void Salir()
        {
            Seleccionar();
            this.Close();
        }

        private void FormularioBaseListado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Salir();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Seleccionar();
            this.Close();
        }

        #endregion

    }
}
