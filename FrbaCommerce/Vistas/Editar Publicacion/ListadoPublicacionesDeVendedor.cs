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
using FrbaCommerce.Vistas.Abm_Rubro;
using FrbaCommerce.Generics;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Vistas.Editar_Publicacion
{
    public partial class ListadoPublicacionesDeVendedor : FormBaseListado
    {

        private VisibilidadDB visiDB;
        private EstadoPublicacionDB estadoDB;
        private PublicacionDB publiDB;
        private Rubro rubroSeleccionado;
        private Usuario usuario_publicador;

        public ListadoPublicacionesDeVendedor(Usuario usuario)
        {
            this.usuario_publicador = usuario;
            this.visiDB = new VisibilidadDB();
            this.estadoDB = new EstadoPublicacionDB();
            this.publiDB = new PublicacionDB();
            InitializeComponent();
        }

        #region [AccionIniciar]
        protected override void AccionIniciar()
        {
            this.CargarComboVisibilidad();
            this.CargarComboEstados();
            this.CargarComboTipoPublicacion();
            this.dp_Fecha_de_inicio.Value = DateManager.Ahora();
            this.dp_Fecha_de_vencimiento.Value = DateManager.Ahora();
            this.btn_Habilitacion.Visible = false;
        }

        private void CargarComboTipoPublicacion() {
            ListaTipoPublicacion lista = new ListaTipoPublicacion();
            this.cb_Tipo_de_publicacion.DataSource = lista.Todos;
            this.cb_Tipo_de_publicacion.DisplayMember = "Nombre";
            this.cb_Tipo_de_publicacion.ValueMember = "Id";
        }

        private void CargarComboEstados() {
            IList<EstadoPublicacion> estados = new List<EstadoPublicacion>();
            EstadoPublicacion estado = new EstadoPublicacion();
            estado.id_estado = 99;
            estado.descripcion = "";
            estados.Add(estado);
            foreach (EstadoPublicacion est in this.estadoDB.ObtenerTodos()) {
                estados.Add(est);
            }
            this.cb_Estado.DataSource = estados;
            this.cb_Estado.DisplayMember = "descripcion";
            this.cb_Estado.ValueMember = "id_estado";
        }

        private void CargarComboVisibilidad() {
            IList<Visibilidad> visibilidades = new List<Visibilidad>();
            Visibilidad visi = new Visibilidad();
            visi.id_visibilidad = 99;
            visi.descripcion = "";
            visibilidades.Add(visi);
            foreach (Visibilidad est in this.visiDB.ObtenerTodos())
            {
                visibilidades.Add(est);
            }
            this.cb_Visibilidad.DataSource = visibilidades;
            this.cb_Visibilidad.DisplayMember = "descripcion";
            this.cb_Visibilidad.ValueMember = "id_visibilidad";
        }
        #endregion

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            this.tb_Descripcion.Text = "";
            this.dp_Fecha_de_inicio.Value = DateManager.Ahora();
            this.dp_Fecha_de_vencimiento.Value = DateManager.Ahora();
            this.cb_Estado.SelectedIndex = 0;
            this.cb_Visibilidad.SelectedIndex = 0;
            this.tb_Rubro.Text = "";
            this.rubroSeleccionado = null;
            this.cb_Tipo_de_publicacion.SelectedIndex = 0;
            this.Filtrar();
        }
        #endregion

        #region [AccionAlta]
        protected override void AccionAlta()
        {
            using (Generar_Publicacion.SeleccionTipoPublicacion form = new Generar_Publicacion.SeleccionTipoPublicacion(this.usuario_publicador)) {

                form.ShowDialog(this);
            }
        }
        #endregion

        #region [AccionFiltrar]
        protected override void AccionFiltrar()
        {
            FiltroPublicacion filtro = this.armarFiltro();
            IResultado<IList<Publicacion>> resultado = this.getPublicacionesFiltradas(filtro);

            if (!resultado.Correcto)
                MessageDialog.MensajeError(resultado.Mensajes.First());

            IList<PublicacionAMostrar> lista = this.armarPublicacionAMostrar(resultado);

            this.dgvBusqueda.DataSource = lista;
            this.PrepararGrillaAMostrar();
            //this.dgvBusqueda.DataSource = resultado.Retorno;
            //this.PrepararGrillaComun();
           
        }

        private void PrepararGrillaAMostrar()
        {
            this.dgvBusqueda.Columns["id_visibilidad"].Visible = false;
            this.dgvBusqueda.Columns["id_estado"].Visible = false;
            this.dgvBusqueda.Columns["id_rubro"].Visible = false;
            this.dgvBusqueda.Columns["habilitada"].Visible = false;
            this.dgvBusqueda.Columns["id_publicacion"].Visible = false;
            this.dgvBusqueda.Columns["id_usuario_publicador"].Visible = false;

            this.dgvBusqueda.Columns["desc_estado"].HeaderText = "Estado";
            this.dgvBusqueda.Columns["desc_rubro"].HeaderText = "Rubro";
            this.dgvBusqueda.Columns["fecha_inicio"].HeaderText = "Visibilidad";
            this.dgvBusqueda.Columns["desc_visibilidad"].HeaderText = "Descripcion";
            this.dgvBusqueda.Columns["stock"].HeaderText = "Stock";
            this.dgvBusqueda.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";
            this.dgvBusqueda.Columns["fecha_vencimiento"].HeaderText = "Fecha de vencimiento";
            this.dgvBusqueda.Columns["precio"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["permite_preguntas"].HeaderText = "Permite preguntas";
            this.dgvBusqueda.Columns["tipo_publicacion"].HeaderText = "Tipo de publicacion";
            this.dgvBusqueda.Columns["username_publicador"].HeaderText = "Usuario que publicó";
        }

        private void PrepararGrillaComun() {
            this.dgvBusqueda.Columns["visibilidad"].Visible = false;
            this.dgvBusqueda.Columns["estado"].Visible = false;
            this.dgvBusqueda.Columns["rubro"].Visible = false;
            this.dgvBusqueda.Columns["habilitada"].Visible = false;
            this.dgvBusqueda.Columns["id_publicacion"].Visible = false;
            this.dgvBusqueda.Columns["usuario_publicador"].Visible = false;

            this.dgvBusqueda.Columns["descripcion"].HeaderText = "Descripcion";
            this.dgvBusqueda.Columns["stock"].HeaderText = "Stock";
            this.dgvBusqueda.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";
            this.dgvBusqueda.Columns["fecha_vencimiento"].HeaderText = "Fecha de vencimiento";
            this.dgvBusqueda.Columns["precio"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["permite_preguntas"].HeaderText = "Permite preguntas";
            this.dgvBusqueda.Columns["tipo_publicacion"].HeaderText = "Tipo de publicacion";
            this.dgvBusqueda.Columns["usuario_publicador"].HeaderText = "Usuario que publicó";
        }

        private FiltroPublicacion armarFiltro(){

            FiltroPublicacion filtro = new FiltroPublicacion();
            filtro.descripcion = tb_Descripcion.Text;
            filtro.rubro = this.rubroSeleccionado;

            if (cb_Tipo_de_publicacion.SelectedIndex != 0)
                filtro.tipo_publicacion = (TipoPublicacion)cb_Tipo_de_publicacion.SelectedItem;
            if (cb_Visibilidad.SelectedIndex != 0)
                filtro.visibilidad = (Visibilidad)cb_Visibilidad.SelectedItem;
            if(cb_Estado.SelectedIndex!=0)
                filtro.estado = (EstadoPublicacion)cb_Estado.SelectedItem;
            filtro.id_usuario_publicador = this.usuario_publicador.id_usuario;
             
            if(this.chb_Fecha_inicio.Checked)
                filtro.fecha_inicio = this.dp_Fecha_de_inicio.Value;
            if(this.chb_Fecha_de_vencimiento.Checked)
                filtro.fecha_vencimiento = this.dp_Fecha_de_vencimiento.Value;
            
            return filtro;
        }

        private IResultado<IList<Publicacion>> getPublicacionesFiltradas(FiltroPublicacion filtro)
        {
            Resultado<IList<Publicacion>> resultado = new Resultado<IList<Publicacion>>();
            try
            {
                resultado.Retorno = this.publiDB.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        private int EjecutarComando(string comando)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = FrbaCommerce.ConnectorDB.DBConnection.getConnection;
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(comando))
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                rowsAffected = sqlCommand.ExecuteNonQuery();
            }

            sqlConnection.Close();
            return rowsAffected;
        }

        #endregion

        #region Accion Modificar
        protected override void AccionModificar()
        {
            //Publicacion publicacion = this.EntidadSeleccionada as Publicacion;
            PublicacionAMostrar pubShow = this.EntidadSeleccionada as PublicacionAMostrar;
            Publicacion publicacion = this.rearmarPublicacion(pubShow);
            ModificarPublicacion frm = new ModificarPublicacion(publicacion, this.usuario_publicador);
            frm.ShowDialog(this);
        }
        #endregion

        #region [Seleccionar rubro]
        private void btn_Seleccionar_rubro_Click(object sender, EventArgs e)
        {
            Rubro rubro = null;
            using (ListadoRubros frm = new ListadoRubros())
            {
                frm.ShowDialog(this);
                if (!frm.cerrado)
                    rubro = frm.EntidadSeleccionada as Rubro;
            }

            if (rubro != null)
            {
                this.CargarRubro(rubro);
                this.btn_Seleccionar.Visible = false;
                this.btn_Limpiar_rubro.Visible = true;
            }
        }

        private void btn_Limpiar_rubro_Click(object sender, EventArgs e)
        {
            this.btn_Limpiar_rubro.Visible = false;
            this.btn_Seleccionar.Visible = true;
            this.tb_Rubro.Text = "";

        }

        private void CargarRubro(Rubro rubro) {
            this.rubroSeleccionado = rubro;
            this.tb_Rubro.Text = rubro.descripcion;
        }
        #endregion

        #region Metodos privados 
        private Publicacion rearmarPublicacion(PublicacionAMostrar pubshow)
        {
            Publicacion pub = new Publicacion();
            pub.id_publicacion = pubshow.id_publicacion;
            pub.permite_preguntas = pubshow.permite_preguntas;
            pub.precio = pubshow.precio;
            pub.descripcion = pubshow.descripcion;
            pub.stock = pubshow.stock;
            pub.tipo_publicacion = pubshow.tipo_publicacion;
            pub.fecha_inicio = pubshow.fecha_inicio;
            pub.fecha_vencimiento = pubshow.fecha_vencimiento;
            pub.usuario_publicador = new Usuario();
            pub.usuario_publicador.id_usuario = pubshow.id_usuario_publicador;
            pub.usuario_publicador.username = pubshow.username_publicador;
            pub.visibilidad = new Visibilidad();
            pub.visibilidad.id_visibilidad = pubshow.id_visibilidad;
            pub.visibilidad.descripcion = pubshow.desc_visibilidad;
            pub.estado = new EstadoPublicacion();
            pub.estado.id_estado = pubshow.id_estado;
            pub.estado.descripcion = pubshow.desc_estado;
            pub.rubro = new Rubro();
            pub.rubro.id_rubro = pubshow.id_rubro;
            pub.rubro.descripcion = pubshow.desc_rubro;
            return pub;
        }

        private IList<PublicacionAMostrar> armarPublicacionAMostrar(IResultado<IList<Publicacion>> resultado)
        {
            IList<PublicacionAMostrar> lista = new List<PublicacionAMostrar>();
            foreach (Publicacion pub in (List<Publicacion>)resultado.Retorno)
            {
                PublicacionAMostrar pubShow = new PublicacionAMostrar();
                pubShow.desc_estado = pub.estado.descripcion;
                pubShow.id_estado = pub.estado.id_estado;
                pubShow.id_rubro = pub.rubro.id_rubro;
                pubShow.desc_rubro = pub.rubro.descripcion;
                pubShow.desc_visibilidad = pub.visibilidad.descripcion;
                pubShow.id_usuario_publicador = pub.usuario_publicador.id_usuario;
                pubShow.username_publicador = pub.usuario_publicador.username;
                pubShow.descripcion = pub.descripcion;
                pubShow.fecha_inicio = pub.fecha_inicio;
                pubShow.fecha_vencimiento = pub.fecha_vencimiento;
                pubShow.habilitada = pub.habilitada;
                pubShow.id_publicacion = pub.id_publicacion;
                pubShow.permite_preguntas = pub.permite_preguntas;
                pubShow.precio = pub.precio;
                pubShow.stock = pub.stock;
                pubShow.tipo_publicacion = pub.tipo_publicacion;
                lista.Add(pubShow);
            }
            return lista;
        }

        private class PublicacionAMostrar
        {
            public decimal id_publicacion { get; set; }
            public decimal id_usuario_publicador { get; set; }
            public string username_publicador { get; set; }
            public string descripcion { get; set; }
            public decimal stock { get; set; }
            public DateTime fecha_inicio { get; set; }
            public DateTime fecha_vencimiento { get; set; }
            public decimal precio { get; set; }
            public bool permite_preguntas { get; set; }
            public TipoPublicacion tipo_publicacion { get; set; }
            public string desc_visibilidad { get; set; }
            public decimal id_visibilidad { get; set; }
            public string desc_estado { get; set; }
            public decimal id_estado { get; set; }
            public string desc_rubro { get; set; }
            public decimal id_rubro { get; set; }
            public bool habilitada { get; set; }
        }
        #endregion

        

    }
}
