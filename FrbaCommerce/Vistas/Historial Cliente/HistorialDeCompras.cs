using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Vistas.Historial_Cliente
{
    public partial class HistorialDeCompras : HistorialGenerico
    {
        public HistorialDeCompras(Usuario usu)
            :base(usu)
        {
            //InitializeComponent();
            this.Text = "Historial de compras";
        }

        protected override void LlenarGrilla()
        {
            DataSet ds = this.historialDB.pedir_Compras(this.usuarioActual);

            this.dgv_Historial.AutoGenerateColumns = true;
            this.dgv_Historial.DataSource = ds.Tables[0];
        }
    }
}
