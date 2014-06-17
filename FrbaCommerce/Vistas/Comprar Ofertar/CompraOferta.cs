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
            button5.Enabled = false;

            //cargamos el combobox de rubros
            RubroDB ru = new RubroDB();
            DataSet da = (DataSet)ru.dame_Rubros();

            comboBox1.DataSource = da.Tables[0];
            comboBox1.DisplayMember = "descripcion";

            scrollVal = 0; 

        }

        public void button1_Click(object sender, EventArgs e)
        {
            // al clickear filtrar generamos la busqueda de las publicaciones
            ComprarOfertarDB co = new ComprarOfertarDB();

            DataSet ds = co.dame_Publicaciones(scrollVal, textBox1.Text, comboBox1.Text);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];
            // habilitamos los otros botones
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // metodo avanzar (paginacion)
            scrollVal = scrollVal + 5;

            ComprarOfertarDB co = new ComprarOfertarDB();
            DataSet ds = co.dame_Publicaciones(scrollVal, textBox1.Text, comboBox1.Text);
            
            // nos cuidamos de exeder la cantidad de paginas, con respecto al numero de la totalidad de la lista
            if (ds.Tables[0].Rows.Count == 5)
            {
                
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
                
            }
            else
            {
                // si llegamos al tope de la lista, mostramos solo el sobrante y detenemos el avance
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
            //// metodo retroceder (paginacion)
            scrollVal = scrollVal - 5;
            if (scrollVal <= 0)
            {
                scrollVal = 0;
            }

            ComprarOfertarDB co = new ComprarOfertarDB();

            DataSet ds = co.dame_Publicaciones(scrollVal, textBox1.Text, comboBox1.Text);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];
            
            // en el caso de llegar al final y clickeamos retroceder, habilitamos el boton avanzar
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Del dataset, selecciono objetos y los convierto
            DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            var id_p = row["id_publicacion"];
            string id_pub = id_p.ToString();

            var preg = row["permite_preguntas"];
            string id_guard = preg.ToString();

            // Controlo que la publicacion permita preguntas a realizar
            if (Convert.ToInt32(id_guard) == 1)
            {
                PreguntasDB pre = new PreguntasDB();
                pre.guarda_Pregunta(textBox2.Text, Convert.ToDecimal(id_pub), usuarioActual.id_usuario);

            }
            else {
                MessageDialog.MensajeError("La publicacion que selecciono, no permite preguntas");
            }        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            var id_t = row["id_tipo_publicacion"];
            string id_tipo = id_t.ToString();
            int id = Convert.ToInt32(id_tipo);
            
            // En caso de comprar u ofertar toma distintos caminos
            if (id == 1) {
                Compra formComp = new Compra(usuarioActual, drv);
                formComp.ShowDialog();
            }
            if (id == 2) {
                Oferta formOfer = new Oferta(usuarioActual, drv);
                formOfer.ShowDialog();
            }
        }

        

      

    }
}
