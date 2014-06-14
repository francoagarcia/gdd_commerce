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
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.Generics;

namespace FrbaCommerce.Vistas.Abm_Empresa
{
    public partial class ListadoEmpresa : FormBaseListado
    {
        private EmpresaDB empresaDB;

        public ListadoEmpresa()
        {
            this.empresaDB = new EmpresaDB();
            InitializeComponent();
            this.chBox_Habilitados.Checked = true;
        }

        #region [Event Load]
        private void ListadoEmpresa_Load(object sender, EventArgs e)
        {
            this.AccionLimpiar();
        }
        #endregion

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            this.tb_CUIT.Text = "";
            this.tb_Mail.Text = "";
            this.tb_Razon_social.Text = "";
        }
        #endregion

        #region [AccionIniciar]
        protected override void AccionIniciar()
        {
            this.AccionLimpiar();
        }
        #endregion

        #region [AccionAlta]
        protected override void AccionAlta()
        {
            AltaEmpresa formEmp = new AltaEmpresa();
            formEmp.ShowDialog();
        }
        #endregion

        #region [AccionBorrar]
        protected override void AccionBorrar()
        {
            Empresa seleccionado = this.EntidadSeleccionada as Empresa;
            this.habilitacionDelRegistro(seleccionado);
            this.Filtrar();
        }

        private void habilitacionDelRegistro(Empresa empresaModif)
        {
            try
            {
                if (empresaModif.habilitada)
                {
                    this.empresaDB.inHabilitarEmpresa(empresaModif);
                    empresaModif.habilitada = false;
                }
                else
                {
                    this.empresaDB.habilitarEmpresa(empresaModif);
                    empresaModif.habilitada = true;
                }
            }
            catch (SqlException exSQL)
            {
                MessageDialog.MensajeError(exSQL.Message);
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
            }
        }
        #endregion

        #region [AccionModificar]
        protected override void AccionModificar()
        {
            Empresa seleccionada = this.EntidadSeleccionada as Empresa;
            using (ModificarEmpresa FrmModif = new ModificarEmpresa(seleccionada)) {
                FrmModif.ShowDialog(this);
            }

        }
        #endregion

        #region [AccionFiltrar]
        protected override void AccionFiltrar()
        {
            FiltroEmpresa filtro = this.prepararFiltroEmpresa();
            IResultado<IList<Empresa>> resultado = this.getEmpresasFiltrados(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Empresa>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;

            this.dgvBusqueda.Columns["id_usuario"].Visible = false;
            this.dgvBusqueda.Columns["telefono"].Visible = false;
            this.dgvBusqueda.Columns["username"].Visible = false;
            this.dgvBusqueda.Columns["contrasenia"].Visible = false;
            this.dgvBusqueda.Columns["cantidadIntentos"].Visible = false;
        }

        private IResultado<IList<Empresa>> getEmpresasFiltrados(FiltroEmpresa filtro) 
        {
            Resultado<IList<Empresa>> resultado = new Resultado<IList<Empresa>>();
            try
            {
                resultado.Retorno = this.empresaDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        private FiltroEmpresa prepararFiltroEmpresa() {
            FiltroEmpresa filtro = new FiltroEmpresa();
            filtro.CUIT = this.tb_CUIT.Text;
            filtro.mail = this.tb_Mail.Text;
            filtro.razon_social = this.tb_Razon_social.Text;
            filtro.habilitada = this.chBox_Habilitados.Checked;
            return filtro;
        }

        #endregion

        private void btnModificacion_Click(object sender, EventArgs e)
        {

        }

    }
}
