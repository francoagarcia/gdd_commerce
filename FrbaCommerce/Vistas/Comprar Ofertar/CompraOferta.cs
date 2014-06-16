using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;
using FrbaCommerce.ConnectorDB;
using System.Data.SqlClient;
using FrbaCommerce;
using FrbaCommerce.Entidades;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.Vistas.Comprar_Ofertar 
{
    public partial class CompraOferta : Form
    {

        static int scrollVal;
    
        private Usuario usuarioActual;

        public CompraOferta(Usuario usu)

        {
            
            this.usuarioActual = usu;
            InitializeComponent();

            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;

            RubroDB ru = new RubroDB();
            DataSet da = (DataSet)ru.dame_Rubros();

            comboBox1.DataSource = da.Tables[0];
            comboBox1.DisplayMember = "descripcion";

            scrollVal = 0; 

        }

        public void button1_Click(object sender, EventArgs e)
        {
            ComprarOfertarDB co = new ComprarOfertarDB();

            DataSet ds = co.dame_Publicaciones(scrollVal, textBox1.Text, comboBox1.Text);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];
            // habilitamos los otros botones
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            scrollVal = scrollVal + 5;

            ComprarOfertarDB co = new ComprarOfertarDB();
            DataSet ds = co.dame_Publicaciones(scrollVal, textBox1.Text, comboBox1.Text);
            if (ds.Tables[0].Rows.Count == 5)
            {
                
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
                
            }
            else
            {
                
                button4.Enabled = false;
                int solo = scrollVal - ds.Tables.Count;
                int posta = (scrollVal - 5) + solo;
                DataSet dc = co.dame_Publicaciones(posta, textBox1.Text, comboBox1.Text);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dc.Tables[0];
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            scrollVal = scrollVal - 5;
            if (scrollVal <= 0)
            {
                scrollVal = 0;
            }

            ComprarOfertarDB co = new ComprarOfertarDB();

            DataSet ds = co.dame_Publicaciones(scrollVal, textBox1.Text, comboBox1.Text);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            var id_p = row["id_publicacion"];
            string id_pub = id_p.ToString();

            var preg = row["permite_preguntas"];
            string id_guard = preg.ToString();
            if (Convert.ToInt32(id_guard) == 1)
            {
                PreguntasDB pre = new PreguntasDB();
                pre.guarda_Pregunta(textBox2.Text, Convert.ToDecimal(id_pub), usuarioActual.id_usuario);

            }
            else {
                MessageDialog.MensajeError("Ha ocurrido un error fatal. Revise el archivo de log para obtener más información al respecto.");
            }        
        }

        

      

    }
}
