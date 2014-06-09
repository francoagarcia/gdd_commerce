using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Abm_Visibilidad
{
    public partial class AltaVisibilidad : Form
    {
        public AltaVisibilidad()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VisibilidadDB vi = new VisibilidadDB();
            vi.crearVisibilidad(textBox2.Text, Convert.ToDecimal(textBox3.Text), Convert.ToDecimal(textBox4.Text));

        }
    }
}
