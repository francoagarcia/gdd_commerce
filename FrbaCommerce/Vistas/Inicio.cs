using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Vistas.Abm_Cliente;

namespace FrbaCommerce
{
    public partial class Inicio : Form
    {
        private Form seleccion_cli;
        private Form alta_cli;

        public Inicio()
        {
            InitializeComponent();
        }

        private void BusquedaCliente_Click(object sender, EventArgs e)
        {
            seleccion_cli = new SeleccionClientes();
            seleccion_cli.Show();
        }

        private void buttonClienteAlta_Click(object sender, EventArgs e)
        {
            alta_cli = new AltaCliente();
            alta_cli.Show();
        }
    }
}
