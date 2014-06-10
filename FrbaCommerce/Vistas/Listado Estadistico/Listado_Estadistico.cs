using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {
        public Listado_Estadistico()
        {
            InitializeComponent();
        }

        private void Listado_Estadistico_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "") {

                if (textBox1.Text != "") {

                    ListadoDB li = new ListadoDB();
                    switch (comboBox1.SelectedIndex) {

                        case 0: DataSet ds = li.pedimeLista("DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos", Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = ds.Tables[0];
                            
                                break;

                        case 1: DataSet du = li.pedimeLista("DATA_GROUP.getTop5VendedoresConMayorFacturacion", Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = du.Tables[0];
                                
                                break;

                        case 2: DataSet dv = li.pedimeLista("DATA_GROUP.getTop5VendedoresConMayorCalificaciones", Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = dv.Tables[0];
                            
                            
                                break;

                        case 3: DataSet dn = li.pedimeLista("DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar", Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = dn.Tables[0];
                            
                                break;


                    }
                
                }
            }
        }
    }
}
