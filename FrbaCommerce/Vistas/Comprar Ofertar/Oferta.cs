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
    public partial class Oferta : Form
    {
        static DataRow row;
        static decimal precio;

        private Usuario usuarioActual;
        public Oferta(Usuario usuario, DataRowView data)
        {
            this.usuarioActual = usuario;

            DataRow row = data.Row;

            // consigo el precio objeto y lo transformo
            var st = row["precio"];
            string id_tipo = st.ToString();
            decimal precio = Convert.ToDecimal(id_tipo);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal monto = Convert.ToDecimal(textBox1.Text);
            if (textBox1.Text != "")
            {
                // consigo el id_publicacion
                var st = row["id_publicacion"];
                string id_tipo = st.ToString();
                decimal id_p = Convert.ToDecimal(id_tipo);

                //en base al id publicacion, consigo el monto ofertado actual
                ComprarOfertarDB comp = new ComprarOfertarDB();
                DataSet ofertado = comp.get_Monto(id_p);
                decimal oferta = Convert.ToDecimal(ofertado.Tables[0].Rows[0][0].ToString());

                if ((monto > precio) || (monto > oferta))
                {

                    comp.agregar_Oferta(id_p, usuarioActual.id_usuario, monto);

                }

            }

        }
    }
}
