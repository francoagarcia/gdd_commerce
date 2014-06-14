using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    public partial class Pregunta : Form
    {
        public Pregunta()
        {
            InitializeComponent();

            PreguntasDB Preg = new PreguntasDB();

            DataSet ds = Preg.dame_Preguntas(textBox1.Text);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];

            DataSet dp = Preg.dame_Respuestas(textBox1.Text);

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = dp.Tables[0];
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            var id = row["id_pregunta"];
            string id_guard = id.ToString();

            PreguntasDB pre = new PreguntasDB();
            pre.guarda_Respuesta(Convert.ToDecimal(id_guard), textBox1.Text);
        }
    }
}
