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

namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    public partial class ListadoUsuarios : FormBaseListado
    {
        private UsuarioDB usuarioDB;

        public ListadoUsuarios()
            : base(true)
        {
            InitializeComponent();
            this.usuarioDB = new UsuarioDB();
            this.btn_Seleccionar.Visible = true;
            this.btn_Seleccionar.Enabled = true;
        }

        protected override void AccionIniciar()
        {
        }

        #region [AccionFiltrar]
        protected override void AccionFiltrar()
        {
            FiltroUsuario filtro = new FiltroUsuario();
            filtro.username = tb_Nombre_de_usuario.Text;
            if (!string.IsNullOrEmpty(tb_Telefono.Text))
                filtro.telefono = Convert.ToDecimal(tb_Telefono.Text);

            IResultado<IList<Usuario>> resultado = this.getUsuariosFiltrados(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Usuario>>(resultado);

            this.dgvBusqueda.DataSource = resultado.Retorno;

            //this.dgvBusqueda.Columns["id_usuario"].Visible = false;
            this.dgvBusqueda.Columns["cantidadIntentos"].Visible = false;
            this.dgvBusqueda.Columns["contrasenia"].Visible = false;
        }

        private IResultado<IList<Usuario>> getUsuariosFiltrados(FiltroUsuario filtro)
        {
            Resultado<IList<Usuario>> resultado = new Resultado<IList<Usuario>>();
            try
            {
                resultado.Retorno = this.usuarioDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }
        #endregion 

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            this.tb_Nombre_de_usuario.Text = "";
            this.tb_Telefono.Text = "";
        }
        #endregion

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
