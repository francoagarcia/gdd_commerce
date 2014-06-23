using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.ConnectorDB;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class DatosDelVendedor : Form
    {
        private Publicacion publi;

        public DatosDelVendedor(Publicacion publi)
        {
            this.publi = publi;
            InitializeComponent();
        }

        private void DatosDelVendedor_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla() 
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18);
            id_usuario.Value = this.publi.usuario_publicador.id_usuario;
            parametros.Add(id_usuario);
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getDatosDelVendedor", parametros);

            this.dgv_Datos_del_vendedor.DataSource = ds.Tables[0];
        }
    }
}
