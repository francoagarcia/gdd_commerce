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

namespace FrbaCommerce.Vistas.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {
        private EstadisticasDB estadisDB;
        private VisibilidadDB visiDB;

        public Listado_Estadistico()
        {
            this.estadisDB = new EstadisticasDB();
            this.visiDB = new VisibilidadDB();
            InitializeComponent();
        }

        #region Event Load
        private void Listado_Estadistico_Load_1(object sender, EventArgs e)
        {
            this.CargarCombos();
        }

        private void CargarCombos()
        {
            this.CargarComboAnio();
            this.CargarComboTrimestres();
            this.CargarListadosEstadisticos();
            this.CargarComboMesSegunTrimestre();
            this.CargarVisibilidades();
        }

        private void CargarVisibilidades()
        {
            List<KeyValuePair<string, int>> visibilidades = new List<KeyValuePair<string, int>>();
            visibilidades.Add(new KeyValuePair<string, int>("                -       ", 0));
            IList<Visibilidad> visis = this.visiDB.ObtenerTodos();
            foreach (Visibilidad vi in visis)
            {
                visibilidades.Add(new KeyValuePair<string, int>(vi.descripcion, Convert.ToInt32(vi.id_visibilidad)));
            }
            this.cb_Visibilidad.DataSource = visibilidades;
            this.cb_Visibilidad.DisplayMember = "Key";
            this.cb_Visibilidad.ValueMember = "Value";
        }

        private void CargarComboMesSegunTrimestre()
        {
            List<KeyValuePair<string, int>> meses = new List<KeyValuePair<string, int>>();
            meses.Add(new KeyValuePair<string, int>("              -   ", 0));
            if (this.cb_Trimestre.SelectedIndex.Equals(0))
            {
                meses.Add(new KeyValuePair<string, int>("Enero", 1));
                meses.Add(new KeyValuePair<string, int>("Febrero", 2));
                meses.Add(new KeyValuePair<string, int>("Marzo", 3));
                meses.Add(new KeyValuePair<string, int>("Abril", 4));
                meses.Add(new KeyValuePair<string, int>("Mayo", 5));
                meses.Add(new KeyValuePair<string, int>("Junio", 6));
                meses.Add(new KeyValuePair<string, int>("Julio", 7));
                meses.Add(new KeyValuePair<string, int>("Agosto", 8));
                meses.Add(new KeyValuePair<string, int>("Septiembre", 9));
                meses.Add(new KeyValuePair<string, int>("Octubre", 10));
                meses.Add(new KeyValuePair<string, int>("Noviembre", 11));
                meses.Add(new KeyValuePair<string, int>("Diciembre", 12));
            }
            else if (this.cb_Trimestre.SelectedIndex.Equals(1))
            {
                meses.Add(new KeyValuePair<string, int>("Enero", 1));
                meses.Add(new KeyValuePair<string, int>("Febrero", 2));
                meses.Add(new KeyValuePair<string, int>("Marzo", 3));
            }
            else if (this.cb_Trimestre.SelectedIndex.Equals(2))
            {
                meses.Add(new KeyValuePair<string, int>("Abril", 4));
                meses.Add(new KeyValuePair<string, int>("Mayo", 5));
                meses.Add(new KeyValuePair<string, int>("Junio", 6));
            }
            else if (this.cb_Trimestre.SelectedIndex.Equals(3))
            {
                meses.Add(new KeyValuePair<string, int>("Julio", 7));
                meses.Add(new KeyValuePair<string, int>("Agosto", 8));
                meses.Add(new KeyValuePair<string, int>("Septiembre", 9));
            }
            else if (this.cb_Trimestre.SelectedIndex.Equals(4))
            {
                meses.Add(new KeyValuePair<string, int>("Octubre", 10));
                meses.Add(new KeyValuePair<string, int>("Noviembre", 11));
                meses.Add(new KeyValuePair<string, int>("Diciembre", 12));
            }
            this.cb_Mes.DataSource = meses;
            this.cb_Mes.ValueMember = "Value";
            this.cb_Mes.DisplayMember = "Key";
        }

        private void CargarListadosEstadisticos()
        {
            List<KeyValuePair<string, int>> listados = new List<KeyValuePair<string, int>>();
            listados.Add(new KeyValuePair<string, int>("                                                 -       ", 0));
            listados.Add(new KeyValuePair<string, int>("Vendedores con mayor cantidad de productos no vendidos", 1));
            listados.Add(new KeyValuePair<string, int>("Vendedores con mayor facturacion", 2));
            listados.Add(new KeyValuePair<string, int>("Vendedores con mayor calificaciones", 3));
            listados.Add(new KeyValuePair<string, int>("Cliente con mayor cantidad de publicaciones sin calificar", 4));
            this.cb_Vista.DisplayMember = "Key";
            this.cb_Vista.ValueMember = "Value";
            this.cb_Vista.DataSource = listados;
        }

        private void CargarComboTrimestres()
        {
            List<KeyValuePair<string, int>> trimestres = new List<KeyValuePair<string, int>>();
            trimestres.Add(new KeyValuePair<string, int>("                 -     ", 0));
            trimestres.Add(new KeyValuePair<string, int>("Primer", 1));
            trimestres.Add(new KeyValuePair<string, int>("Segundo", 2));
            trimestres.Add(new KeyValuePair<string, int>("Tercero", 3));
            trimestres.Add(new KeyValuePair<string, int>("Cuarto", 4));
            this.cb_Trimestre.DisplayMember = "Key";
            this.cb_Trimestre.ValueMember = "Value";
            this.cb_Trimestre.DataSource = trimestres;
        }

        private void CargarComboAnio()
        {
            IList<string> anios = new List<string>();
            anios.Add("              -   ");
            IList<int> aniosBD = this.estadisDB.getTodosAnios();
            foreach (int anio in aniosBD)
            {
                anios.Add(anio.ToString());
            }
            this.cb_Año.DataSource = anios;
        }

        private void cb_Vista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_Vista.SelectedIndex.Equals(1))
            {
                this.lbl_Mes.Visible = true;
                this.cb_Mes.Visible = true;
                this.cb_Visibilidad.Visible = true;
                this.lbl_Visibilidad.Visible = true;
            }
            else
            {
                this.lbl_Mes.Visible = false;
                this.cb_Mes.Visible = false;
                this.cb_Visibilidad.Visible = false;
                this.lbl_Visibilidad.Visible = false;
            }

            this.ValidarCombosCompletos();
        }

        private void cb_Trimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarComboMesSegunTrimestre();
            this.ValidarCombosCompletos();
        }

        private void cb_Año_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ValidarCombosCompletos();
        }

        private void cb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ValidarCombosCompletos();
        }

        private void cb_Visibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ValidarCombosCompletos();
        }

        private void ValidarCombosCompletos()
        {
            IList<ComboBox> combitos = new List<ComboBox>();
            foreach (Control control in this.gb_Opciones_estadisticas.Controls)
            {
                if (control is ComboBox && ((ComboBox)control).Visible == true)
                    combitos.Add((ComboBox)control);
            }
            this.btn_Consultar.Enabled = combitos.All(c => c.SelectedIndex != 0);
        }

        #endregion

        #region [Consultar]
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Estadistica esta = new Estadistica();
            esta.anio = Convert.ToInt32(this.cb_Año.SelectedItem);
            esta.trimestre = Convert.ToInt32(((KeyValuePair<string, int>)cb_Trimestre.SelectedItem).Value);
            esta.mes = -1;

            //textBox1.Text = Convert.ToString(cb_Vista.SelectedIndex);
            DataSet ds = null;
            switch (cb_Vista.SelectedIndex)
            {
                case 1:
                    esta.mes = Convert.ToInt32(((KeyValuePair<string, int>)cb_Mes.SelectedItem).Value);
                    esta.visibilidad = Convert.ToString(this.cb_Visibilidad.SelectedItem);
                    ds = this.estadisDB.getTop5VendedoresConMasProductosNoVendidos(esta);
                    break;
                case 2:
                    ds = this.estadisDB.getTop5VendedoresConMayorFacturacion(esta);
                    break;
                case 3:
                    ds = this.estadisDB.getTop5VendedoresConMayorCalificaciones(esta);
                    break;
                case 4:
                    ds = this.estadisDB.getTop5ClientesConMasPublicacionesSinCalificar(esta);
                    break;
            }
            dgv_Resultado.AutoGenerateColumns = true;
            dgv_Resultado.DataSource = ds.Tables[0];
        }
        #endregion
    }
}
