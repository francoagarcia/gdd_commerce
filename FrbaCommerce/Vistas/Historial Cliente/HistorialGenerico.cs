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
    public partial class HistorialGenerico : Form
    {
        protected  HistorialDB historialDB;
        protected Usuario usuarioActual;

        public HistorialGenerico(Usuario usu)
        {
            this.usuarioActual = usu;
            this.historialDB = new HistorialDB();
            InitializeComponent();
        }

        private void HistorialGenerico_Load(object sender, EventArgs e)
        {
            this.LlenarGrilla();
        }

        protected virtual void LlenarGrilla() {
            throw new NotImplementedException();
        }
    }
}
