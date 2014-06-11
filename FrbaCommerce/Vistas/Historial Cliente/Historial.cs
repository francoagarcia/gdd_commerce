using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Historial_Cliente
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistorialDB hi = new HistorialDB();

            DataSet ds = hi.pedir_Compras(textBox1.Text);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];


            DataSet dx = hi.pedir_Ofertas(textBox1.Text);

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = dx.Tables[0];

            DataSet dz = hi.pedir_Calificaciones(textBox1.Text);

            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = dz.Tables[0];

            


        }

        private void Historial_Load(object sender, EventArgs e)
        {

        }
    }
}
