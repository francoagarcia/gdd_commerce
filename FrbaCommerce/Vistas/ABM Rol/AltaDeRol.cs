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
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using System.Data.SqlClient;

namespace FrbaCommerce.Vistas.ABM_Rol
{
    public partial class AltaDeRol : FormBaseAlta
    {
        private Rol rol;
        private IList<Funcionalidad> funcionalidades;
        private FuncionalidadDB funcDB;
        private RolDB rolDB;

        public AltaDeRol()
        {
            InitializeComponent();
            this.rol = new Rol(); ;
            this.rolDB = new RolDB();
            this.funcDB = new FuncionalidadDB();
            this.funcionalidades = new List<Funcionalidad>();
        }

        private void AltaDeRol_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Nombre_del_rol, 1, 255));
            this.ch_Habilitado.Checked = true;
            this.CargarListaFuncionalidades();
        }

        private void CargarListaFuncionalidades() 
        {
            this.funcionalidades = this.funcDB.getTodasFuncionalidades();
            foreach (Funcionalidad fun in this.funcionalidades)
            {
                this.list_funcionalidades.Items.Add(fun.Nombre, false);
            }
        }

        #region Cancelar
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion Cancelar

        #region Limpiar
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }

        protected override void AccionLimpiar()
        {
            this.tb_Nombre_del_rol.Text = "";
            for (int i = 0; i < this.list_funcionalidades.Items.Count; i++)
            {
                list_funcionalidades.SetItemChecked(i, false);
            }
        }
        #endregion

        #region Aceptar
        private void btn_Crear_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            this.rol.nombre = this.tb_Nombre_del_rol.Text;
            this.rol.habilitada = this.ch_Habilitado.Checked;
            IList<FuncionalidaXRol> funcs = this.armarFuncionalidades();

            if (this.crearRolDB(funcs))
            {
                MessageDialog.MensajeInformativo(this, "Se creó el rol correctamente");
                this.Close();
            }

        }

        private bool crearRolDB(IList<FuncionalidaXRol> funcs)
        {
            try
            {
                this.rolDB.crearRolCompleto(this.rol, funcs);
            }
            catch (SqlException e)
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            catch (Exception e)
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            return true;
        }

        private IList<FuncionalidaXRol> armarFuncionalidades()
        {
            IList<FuncionalidaXRol> funcs = new List<FuncionalidaXRol>();
            foreach (string item in this.list_funcionalidades.Items)
            {
                FuncionalidaXRol fun = new FuncionalidaXRol();
                fun.rol = this.rol;
                fun.funcionalidad = this.funcionalidades.Where(fr => fr.Nombre.Equals(item)).FirstOrDefault();
                fun.habilitada = this.list_funcionalidades.CheckedItems.Contains(item);
                funcs.Add(fun);
            }
            return funcs;
        }

        #endregion

    }
}
