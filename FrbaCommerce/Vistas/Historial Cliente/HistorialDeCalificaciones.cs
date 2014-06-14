using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.Vistas.Historial_Cliente
{
    public partial class HistorialDeCalificaciones : HistorialGenerico
    {
        public HistorialDeCalificaciones(Usuario usu)
            : base(usu)
        {
            //InitializeComponent();
        }

        protected override void LlenarGrilla()
        {
            DataSet dz = this.historialDB.pedir_Calificaciones(this.usuarioActual);
            this.dgv_Historial.AutoGenerateColumns = true;
            this.dgv_Historial.DataSource = dz.Tables[0];
            this.dgv_Historial.Columns["estrellas_calificacion"].HeaderText = "Cantidad de estrellas";
        }
    }
}
