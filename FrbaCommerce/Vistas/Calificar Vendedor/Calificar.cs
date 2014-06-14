using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Calificar_Vendedor
{
    public partial class Calificar : Form
    {
        public Calificar()
        {
            InitializeComponent();
            string user = "hola";   // definir el nombre del usuario que navega
            CalificacionesDB ca = new CalificacionesDB();

            DataSet ds = ca.dame_Calificaciones(user);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && (Convert.ToInt32(textBox1.Text) >= 0) && (Convert.ToInt32(textBox1.Text) <= 5)) { 
                
                DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                DataRow row = drv.Row;

                var id = row["id_compra"];
                string id_guard = id.ToString();

                //Creo el nuevo registro de calificacion 
                CalificacionesDB cali = new CalificacionesDB();
                decimal id_calificacion = cali.agrega_Calificaciones(textBox2.Text, Convert.ToDecimal(textBox1.Text));

                //El retorno, la id de calificacion, la guardo en la correspondiente compra
                cali.actualizar_Compras(id_calificacion, Convert.ToDecimal(id_guard));

            }


        }
    }
}
