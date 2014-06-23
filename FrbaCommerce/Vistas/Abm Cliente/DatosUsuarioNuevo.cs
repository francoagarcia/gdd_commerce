using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vistas.Abm_Cliente
{
    public partial class DatosUsuarioNuevo : Form
    {
        public DatosUsuarioNuevo(string usuario, string constrasenia)
        {
            InitializeComponent();
            this.tb_Usuario.Text = usuario;
            this.tb_Constrasenia.Text = constrasenia;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
