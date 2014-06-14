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
    public partial class HistorialDeOfertas : HistorialGenerico
    {
        public HistorialDeOfertas(Usuario usu)
            :base(usu)
        {
            //InitializeComponent();
        }

        protected override void LlenarGrilla()
        {
            DataSet dx = this.historialDB.pedir_Ofertas(this.usuarioActual);

            this.dgv_Historial.AutoGenerateColumns = true;
            this.dgv_Historial.DataSource = dx.Tables[0];
        }
    }
}
