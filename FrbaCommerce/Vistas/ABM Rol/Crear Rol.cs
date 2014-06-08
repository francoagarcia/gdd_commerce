using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods;


namespace FrbaCommerce.Vistas.ABM_Rol
{
    public partial class ABMRolC : Form
    {
        public ABMRolC()
        {
            InitializeComponent();
            
            FuncionalidadDB fu = new FuncionalidadDB();
            DataSet ds = (DataSet) fu.pedir_func();
            
            listBox1.DisplayMember = "nombre";
            listBox1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ABMRol_Load(object sender, EventArgs e)
        {

        }

        private void listFunc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bAgregar_Click(object sender, EventArgs e)
        {
            ADD();
        }

        public void ADD()
        {
            int c = listBox1.Items.Count - 1;
            FuncionalidadDB fu = new FuncionalidadDB();
            DataSet ds = (DataSet)fu.pedir_func();

            for (int i = c; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    if (listBox2.Items.Count < 1)
                    {
                        listBox2.Items.Add(ds.Tables[0].Rows[i][1]);
                    }
                    else
                    {
                        int f = listBox2.Items.Count -1;
                        int aux = 0;
                        for (int u = f; u >= 0; u--)
                        {

                            if (listBox2.GetItemText(listBox2.Items[u]) == (listBox1.GetItemText(listBox1.Items[i])))
                            { aux++; 
                            }
                        }
                        
                        if (aux == 0)listBox2.Items.Add(ds.Tables[0].Rows[i][1]);   
                            

                        }

                    }

                }
            
            }
        

        private void buttonOK1_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {

                if (textBoxNomRol1.Text != "")
                {
                    RolDB rol = new RolDB();
                    rol.Crear_Rol(textBoxNomRol1.Text);

                    FuncionalidadDB fun = new FuncionalidadDB();

                    for (int i = 0; i < listBox2.Items.Count; i++)
                        fun.funcionalidadXRol(textBoxNomRol1.Text, listBox2.GetItemText(listBox2.Items[i]));
                }
                else
                {
                    MessageDialog.MensajeVacio("Rol");
                }

            }
            else {
                MessageDialog.MensajeListaVacia();
            }
        }

    }
}
