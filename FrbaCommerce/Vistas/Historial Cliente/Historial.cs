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
    public partial class Historial : Form
    {

        private Usuario usuarioActual;

        public Historial(Usuario usu)
        {
            this.usuarioActual = usu;
            InitializeComponent();
        }

        private void btn_Ver_historial_calificaciones_Click(object sender, EventArgs e)
        {
            using (FrbaCommerce.Vistas.Historial_Cliente.HistorialDeCalificaciones frm = new HistorialDeCalificaciones(this.usuarioActual))
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_Ver_historial_de_compras_Click(object sender, EventArgs e)
        {
            HistorialDeCompras frm = new HistorialDeCompras(this.usuarioActual);
            frm.ShowDialog(this);
        }

        private void btn_Ver_historial_de_ofertas_Click(object sender, EventArgs e)
        {
            HistorialDeOfertas frm = new HistorialDeOfertas(this.usuarioActual);
            frm.ShowDialog(this);
        }
    }
}
