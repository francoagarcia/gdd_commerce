using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;
using System.Data.SqlClient;

namespace FrbaCommerce.Vistas.ABM_Rol
{
    public partial class ListadoRoles : FormBaseListado
    {
        private RolDB rolDB;

        public ListadoRoles()
        {
            this.rolDB = new RolDB();
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            AltaDeRol frm = new AltaDeRol();
            frm.ShowDialog();
        }

        #region Borrar
        protected override void AccionBorrar()
        {
            Rol seleccionado = this.EntidadSeleccionada as Rol;
            if (this.habilitacionDelRegistroDB(seleccionado)) 
            {
                if(seleccionado.habilitada)
                    MessageDialog.MensajeInformativo(this, "Se habilitó el rol correctamente");
                else
                    MessageDialog.MensajeInformativo(this, "Se deshabilitó el rol correctamente");
                this.Filtrar();
            }
           
        }

        private bool habilitacionDelRegistroDB(Rol rol)
        {
            try
            {
                if (rol.habilitada)
                {
                    this.rolDB.deshabilitarRol(rol);
                    rol.habilitada = false;
                }
                else
                {
                    this.rolDB.habilitarRol(rol);
                    rol.habilitada = true;
                }
            }
            catch (SqlException exSQL)
            {
                MessageDialog.MensajeError(exSQL.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;
        }


        #endregion

        #region Filtrar
        protected override void AccionFiltrar()
        {
            FiltroRol filtro = new FiltroRol();
            filtro.nombre = tb_Descripcion_del_rol.Text;

            IResultado<IList<Rol>> resultado = this.getRolesFiltradas(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Rol>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;

        }

        private IResultado<IList<Rol>> getRolesFiltradas(FiltroRol filtro)
        {
            Resultado<IList<Rol>> resultado = new Resultado<IList<Rol>>();
            try
            {
                resultado.Retorno = this.rolDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }


        #endregion

        protected override void AccionIniciar()
        {
            
        }

        protected override void AccionLimpiar()
        {
            this.tb_Descripcion_del_rol.Text = "";
            this.Filtrar();
        }

        protected override void AccionModificar()
        {
            Rol rol = this.EntidadSeleccionada as Rol;
            ModificarRol frm = new ModificarRol(rol);
            frm.ShowDialog(this);
            this.Filtrar();
        }
    }
}
