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
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Vistas.ABM_Rol
{
    public partial class ModificarRol : Form
    {

        public ModificarRol()
        {
            InitializeComponent();

            RolDB ro = new RolDB();
            DataSet da = (DataSet)ro.Mostrar_Roles();

            comboBoxRoles.DataSource = da.Tables[0];
            comboBoxRoles.DisplayMember = "nombre";

            FuncionalidadDB fu = new FuncionalidadDB();
            DataSet ds = (DataSet)fu.pedir_func();

            listBox1.DisplayMember = "nombre";
            listBox1.DataSource = ds.Tables[0];
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
                        int f = listBox2.Items.Count - 1;
                        int aux = 0;
                        for (int u = f; u >= 0; u--)
                        {

                            if (listBox2.GetItemText(listBox2.Items[u]) == (listBox1.GetItemText(listBox1.Items[i])))
                            {
                                aux++;
                            }
                        }

                        if (aux == 0) listBox2.Items.Add(ds.Tables[0].Rows[i][1]);


                    }

                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {

                if (checkBoxHabilitado.Enabled)
                {

                    if (textBox1.Text != "")
                    {

                        //actualizo nombre de rol
                        RolDB rol = new RolDB();
                        rol.Modificar_Rol(comboBoxRoles.Text, textBox1.Text);

                        FuncionalidadDB fun = new FuncionalidadDB();

                        //actualizo funcionalidades
                        for (int i = 0; i < listBox2.Items.Count; i++)
                            fun.funcionalidadXRol(textBox1.Text, listBox2.GetItemText(listBox2.Items[i]));

                        //habilito el rol
                        rol.habilitar(textBox1.Text);

                    }

                }
                else
                {
                    if (textBox1.Text != "")
                    {

                        //actualizo nombre de rol
                        RolDB rol = new RolDB();
                        rol.Modificar_Rol(comboBoxRoles.Text, textBox1.Text);

                        FuncionalidadDB fun = new FuncionalidadDB();

                        //actualizo funcionalidades
                        for (int i = 0; i < listBox2.Items.Count; i++)
                            fun.funcionalidadXRol(textBox1.Text, listBox2.GetItemText(listBox2.Items[i]));

                        //habilito el rol
                        rol.habilitar(textBox1.Text);
                    }
                }
            }

        }

    }

}

