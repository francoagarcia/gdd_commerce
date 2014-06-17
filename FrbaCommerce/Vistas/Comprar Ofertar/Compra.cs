using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.DataAccess;
using FrbaCommerce.Entidades;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class Compra : Form
    {
        static DataRow row;
        private Usuario usuarioActual;
        public Compra(Usuario usuario, DataRowView data)
        {
            this.usuarioActual = usuario;

            DataRow row = data.Row;

            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                int cantidad = Convert.ToInt32(textBox1.Text);
                // cargo el objeto stock del dataset a int stk
                var st = row["Stock"];
                string id_tipo = st.ToString();
                int stk = Convert.ToInt32(id_tipo);

                //solo cargo la compra si tengo stock disponible
                if (stk > cantidad)
                {
                    // cargo el objeto id publicacion del dataset a int id_pub
                    var pu = row["id_publicacion"];
                    string id_p = pu.ToString();
                    int id_pub = Convert.ToInt32(id_p);

                    // actualizo el stock en la publicacion
                    ComprarOfertarDB comp = new ComprarOfertarDB();
                    comp.update_Publicacion(id_pub, (stk - cantidad));

                    // agrego la nuevo compra al sistema
                    comp.agregar_Compra(id_pub, usuarioActual.id_usuario, cantidad);

                    // luego de confirmada la compra se muestra la info del vendedor
                    UsuarioDB usu = new UsuarioDB();
                    DataSet ds = usu.dame_TusDatos(usuarioActual.id_usuario);

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                    MessageDialog.MensajeError("No se ha podido realizar la compra. Usted ha excedido el stock disponible.");
            }

        }
    }
}
