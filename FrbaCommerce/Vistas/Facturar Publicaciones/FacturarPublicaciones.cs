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

namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    public partial class FacturarPublicaciones : Form
    {
        private ListaFormasDePago formasDePago;

        public FacturarPublicaciones()
        {
            this.formasDePago = new ListaFormasDePago();
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Seleccionar_usuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = null;
            using (ListadoUsuarios frm = new ListadoUsuarios())
            {
                frm.ShowDialog(this);
                usuario = frm.EntidadSeleccionada as Usuario;
            }

            if (usuario != null)
            {
                this.tb_Seleccionar_usuario.Text = usuario.username;
            }
        }

        private void FacturarPublicaciones_Load(object sender, EventArgs e)
        {
            this.CargarFormasDePago();
        }

        private void CargarFormasDePago() 
        {
            this.cb_Forma_pago.DataSource = this.formasDePago.Todos;
            this.cb_Forma_pago.DisplayMember = "Nombre";
            this.cb_Forma_pago.ValueMember = "Id";
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.gb_Busqueda.Enabled = true;
            this.gb_Acciones.Enabled = true;

            this.CargarGrilla();
        }

        private void CargarGrilla() {

            
            
        }
    }
}
