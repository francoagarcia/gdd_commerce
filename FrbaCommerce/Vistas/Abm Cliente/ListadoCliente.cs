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

namespace FrbaCommerce.Vistas.Abm_Cliente
{
    public partial class ListadoCliente : FormBaseListado
    {

        private ClienteDB clienteDB;

        public ListadoCliente()
        {
            this.clienteDB = new ClienteDB();
            InitializeComponent();
            this.chBox_Habilitados.Checked = true;
        }

        #region [Accion Iniciar]
        protected override void AccionIniciar()
        {
            this.AccionLimpiar();
            this.CargarCombos();
        }

        private void CargarCombos() {
            //var sexos = new ListaSexo();
            //cb_Sexo.DataSource = sexos.Todos;
            //cb_Sexo.DisplayMember = "Nombre";
            //cb_Sexo.ValueMember = "Id";

            var tipoDocumentos = new ListaTipoDocumento();
            cb_Tipo_de_documento.DataSource = tipoDocumentos.Todos;
            cb_Tipo_de_documento.DisplayMember = "Nombre";
            cb_Tipo_de_documento.ValueMember = "Id";
        }
        #endregion

        #region [AccionAlta]
        protected override void AccionAlta()
        {
            AltaClientes FormAlta = new AltaClientes();
            FormAlta.ShowDialog();
            //Cuando hace el Evento Load ahi vuelve a cargar el nuevo registro
        }
        #endregion

        #region [AccionModificar]
        protected override void AccionModificar()
        {
            Cliente seleccionado = this.EntidadSeleccionada as Cliente;
            using (ModificacionCliente frm = new ModificacionCliente(seleccionado))
            {
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region [AccionFitrar]
        protected override void AccionFiltrar()
        {
            FiltroCliente filtro = this.prepararFiltroCliente();

            IResultado<IList<Cliente>> resultado = this.getClientesFiltrados(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Cliente>>(resultado);
           
            this.dgvBusqueda.DataSource = resultado.Retorno;

            this.dgvBusqueda.Columns["id_usuario"].Visible = false;
            this.dgvBusqueda.Columns["telefono"].Visible = false;
            this.dgvBusqueda.Columns["username"].Visible = false;
            this.dgvBusqueda.Columns["contrasenia"].Visible = false;
            this.dgvBusqueda.Columns["cantidadIntentos"].Visible = false;

        }

        private IResultado<IList<Cliente>> getClientesFiltrados(FiltroCliente filtro)
        {
            Resultado<IList<Cliente>> resultado = new Resultado<IList<Cliente>>();
            try
            {
                resultado.Retorno = this.clienteDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        private FiltroCliente prepararFiltroCliente() {

            FiltroCliente filtro = new FiltroCliente();
            filtro.NroDocumento = tb_Numero_de_Documento.Text;

            if (!string.IsNullOrEmpty(tb_Telefono.Text))
                filtro.Telefono = Convert.ToDecimal(tb_Telefono.Text);

            //if (!string.IsNullOrEmpty(tb_Piso.Text))
            //    filtro.Piso = Convert.ToDecimal(tb_Piso.Text);

            filtro.IdUsuario = 0;
            filtro.IdTipoDocumento = (TipoDocumento)cb_Tipo_de_documento.SelectedItem;
            filtro.Nombre = tb_Nombre.Text;
            filtro.Apellido = tb_Apellido.Text;
            //filtro.Calle = tb_Calle.Text;
            //filtro.Localidad = tb_Localidad.Text;
            //filtro.CodigoPostal = tb_Codigo_postal.Text;
            //filtro.Depto = tb_Departamento.Text;
            filtro.Mail = tb_Mail.Text;
            filtro.Habilitada = chBox_Habilitados.Checked;

            //if (chSexo.Checked)
            //{
            //    filtro.IdSexo = (Sexo)cb_Sexo.SelectedItem;
            //}

            //if (chFechaNac.Checked)
            //{
            //    filtro.FechaDeNacimiento = dtp_Fecha_de_nacimiento.Value;
            //}

            return filtro;

        }
        #endregion

        #region[AccionBaja]
        protected override void AccionBorrar()
        {
            Cliente seleccionado = this.EntidadSeleccionada as Cliente;
            this.habilitacionDelRegistro(seleccionado);
            this.Filtrar();
        }

        private void habilitacionDelRegistro(Cliente clienteModif)
        {
            try
            {
                if (clienteModif.habilitada)
                {
                    this.clienteDB.inHabilitarCliente(clienteModif);
                    clienteModif.habilitada = false;
                }
                else
                {
                    this.clienteDB.habilitarCliente(clienteModif);
                    clienteModif.habilitada = true;
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

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            this.tb_Apellido.Text = "";
            //this.tb_Calle.Text = "";
            //this.tb_Codigo_postal.Text = "";
            //this.tb_Departamento.Text = "";
            //this.tb_Localidad.Text = "";
            this.tb_Mail.Text = "";
            this.tb_Nombre.Text = "";
            this.tb_Numero_de_Documento.Text = "";
            //this.tb_Piso.Text = "";
            this.tb_Telefono.Text = "";
        }
        #endregion

        #region [Evento Load]
        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            AccionLimpiar();
            //this.dtp_Fecha_de_nacimiento.Value = DateManager.Ahora();
            this.CargarCombos();
        }
        #endregion





    }
}
