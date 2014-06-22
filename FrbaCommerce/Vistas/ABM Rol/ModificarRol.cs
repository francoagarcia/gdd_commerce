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
    public partial class ModificarRol : FormBaseModificacion
    {
        private Rol rolModif;
        private IList<FuncionalidaXRol> funcionalidades;
        private FuncionalidadDB funcDB;
        private RolDB rolDB;

        public ModificarRol(Rol _rolModif)
        {
            InitializeComponent();
            this.rolModif = _rolModif;
            this.rolDB = new RolDB();
            this.funcDB = new FuncionalidadDB();
            this.funcionalidades = new List<FuncionalidaXRol>();
        }

        #region Accion iniciar
        protected override void AccionIniciar()
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Nombre_nuevo, 1, 255));
            this.CargarRol();
        }

        private void CargarRol() 
        {
            this.tb_Nombre_nuevo.Text = this.rolModif.nombre;
            this.CargarFuncionalidades();
        }

        private void CargarFuncionalidades() 
        {
            this.funcionalidades = this.funcDB.getFuncDeUnRolHabilYNoHabilitadas(this.rolModif);
            foreach (FuncionalidaXRol fun_rol in this.funcionalidades)
            {
                this.list_funcionalidades.Items.Add(fun_rol.funcionalidad.Nombre, fun_rol.habilitada);
            }
        }
        #endregion

        #region Cancelar
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        #region Aceptar
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            this.rolModif.nombre = this.tb_Nombre_nuevo.Text;
            IList<FuncionalidaXRol> funcs = this.armarFuncionalidades();
            
            if(this.modificarRolDB( funcs )) 
            {
                this.funcionalidades = funcs;
                MessageDialog.MensajeInformativo(this, "Se modifico el registro correctamente");
                this.Close();
            }
            
        }

        private bool modificarRolDB(IList<FuncionalidaXRol> funcs) {

            try
            {
                this.rolDB.modificarRolConFuncionalidades(this.rolModif, funcs);
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
                fun.rol = this.rolModif;
                fun.funcionalidad = this.funcionalidades.Where(fr => fr.funcionalidad.Nombre.Equals(item)).FirstOrDefault().funcionalidad;
                fun.habilitada = this.list_funcionalidades.CheckedItems.Contains(item);
                funcs.Add(fun);
            }
            return funcs;
        }
        #endregion

        #region Limpiar
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }

        protected override void AccionLimpiar()
        {
            this.tb_Nombre_nuevo.Text = "";
            for (int i = 0; i < this.list_funcionalidades.Items.Count; i++)
            {
                list_funcionalidades.SetItemChecked(i, false);
            }
        }

        #endregion



    }

}

