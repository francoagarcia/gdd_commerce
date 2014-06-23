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

namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    public partial class ListadoPublicacionesCompra : FormBase
    {

        #region [Atributos]
        private PublicacionDB publiDB;
        private Rubro rubroSeleccionado;
        private Usuario usuarioActual;
        private EstadoPublicacion estadoActivo;
        //Para la paginacion 
        int PageCount;
        int maxRec;
        int pageSize;
        int currentPage;
        int recNo;
        public object EntidadSeleccionada { get { return Seleccionar(); } }
        #endregion

        #region [Constructores]
        public ListadoPublicacionesCompra(Usuario usuActu)
            :base()
        {
            InitializeComponent();
            this.estadoActivo = new EstadoPublicacion();
            this.estadoActivo.id_estado = 1;
            this.estadoActivo.descripcion = "Publicada";
            this.publiDB = new PublicacionDB();
            this.usuarioActual = usuActu;
            // Initial seeings
            currentPage = 1;
            recNo = 0;
            this.pageSize = 5;
            this.settingsPage(0);

            this.maxRec = 0;
            this.PageCount = maxRec / pageSize;

            //Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }
        }

        private void settingsPage(int countFilas) {
            this.maxRec = countFilas;
            this.PageCount = maxRec / pageSize;

            //Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }
        }

        #endregion

        #region [FormularioBaseListado_Load]
        private void LisadoPublicacionesCompra_Load(object sender, EventArgs e)
        {
            this.Filtrar();
        }
        #endregion

        #region [btnLimpiar]
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea limpiar los campos?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.AccionLimpiar();
            }
        }

        protected void AccionLimpiar()
        {
            this.tb_Descripcion.Text = "";
            this.tb_Rubro.Text = "";
            this.rubroSeleccionado = null;
            this.Filtrar();
        }
        #endregion

        #region [btnFiltrar]
        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            this.recNo = 0;
            this.Filtrar();
        }
        
        protected void Filtrar()
        {
            if (base.Validar())
            {
                this.AccionFiltrar();
            }
        }

        private void AccionFiltrar()
        {
            FiltroPublicacion filtro = this.armarFiltro();
            IResultado<IList<Publicacion>> resultado = this.getPublicacionesFiltradas(filtro);

            if (!resultado.Correcto)
                throw new ResultadoIncorrectoException<IList<Publicacion>>(resultado);

            IList<PublicacionAMostrar> pubs = this.armarPublicacionAMostrar(resultado);
            this.settingsPage(pubs.Count);

            this.dgv_Busqueda.DataSource = this.LoadPage(pubs);
            this.PrepararGrillaAMostrar();
        }

        private IList<PublicacionAMostrar> LoadPage(IList<PublicacionAMostrar> pubs)
        {
            int i;
            int startRec;
            int endRec;
            IList<PublicacionAMostrar> pub_source_temp = new List<PublicacionAMostrar>();

            if (currentPage == PageCount)
            {
                endRec = maxRec;
            }
            else
            {
                endRec = pageSize * currentPage;
            }
            startRec = recNo;
            if (pubs.Count > 0)
            {
                for (i = startRec; i < endRec; i++)
                {
                    pub_source_temp.Add(pubs.ElementAt(i));
                    recNo += 1;
                }
            }
            this.DisplayPageInfo();
            return pub_source_temp;
        }

        private void DisplayPageInfo() {
            lbl_Paginas.Text = "Pagina " + currentPage.ToString() + "/ " + PageCount.ToString();
        }

        private void PrepararGrillaAMostrar()
        {
            this.dgv_Busqueda.Columns["id_publicacion"].Visible = false;
            this.dgv_Busqueda.Columns["id_rubro"].Visible = false;
            this.dgv_Busqueda.Columns["id_visibilidad"].Visible = false;
            this.dgv_Busqueda.Columns["id_estado"].Visible = false;
            this.dgv_Busqueda.Columns["id_usuario_publicador"].Visible = false;

            this.dgv_Busqueda.Columns["desc_visibilidad"].HeaderText = "Visibilidad";
            this.dgv_Busqueda.Columns["desc_rubro"].HeaderText = "Rubro";
            this.dgv_Busqueda.Columns["desc_estado"].HeaderText = "Estado de publicacion";
            this.dgv_Busqueda.Columns["descripcion"].HeaderText = "Descripcion";
            this.dgv_Busqueda.Columns["stock"].HeaderText = "Stock";
            this.dgv_Busqueda.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";
            this.dgv_Busqueda.Columns["fecha_vencimiento"].HeaderText = "Fecha de vencimiento";
            this.dgv_Busqueda.Columns["precio"].HeaderText = "Precio";
            this.dgv_Busqueda.Columns["permite_preguntas"].HeaderText = "Permite preguntas";
            this.dgv_Busqueda.Columns["tipo_publicacion"].HeaderText = "Tipo de publicacion";
        }

        private FiltroPublicacion armarFiltro()
        {
            FiltroPublicacion filtro = new FiltroPublicacion();
            filtro.descripcion = tb_Descripcion.Text;
            filtro.rubro = this.rubroSeleccionado;
            filtro.estado = this.estadoActivo;
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
        #endregion

        #region [btn_Ver_publicacion]
        protected object Seleccionar()
        {
            object seleccionado = null;

            if (dgv_Busqueda.SelectedRows.Count > 0)
            {
                seleccionado = dgv_Busqueda.SelectedRows[0].DataBoundItem;
            }

            return seleccionado;
        }

        private void AgregarBotonSeleccionar()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            this.dgv_Busqueda.Columns.Add(buttonColumn);
        }

        protected void Salir()
        {
            Seleccionar();
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Seleccionar();
            this.Close();
        }

        private void btn_Ver_publicacion_Click(object sender, EventArgs e)
        {
            PublicacionAMostrar publicacionMostrada = this.EntidadSeleccionada as PublicacionAMostrar;
            if (publicacionMostrada == null)
            {
                MessageDialog.MensajeError(this, "Debe seleccionar una publicacion primero");
            }
            else
            {
                if (this.usuarioActual.habilitada_comprar)
                {
                    Publicacion publicacion = this.rearmarPublicacion(publicacionMostrada);
                    PublicacionView frmPub = new PublicacionView(publicacion, this.usuarioActual);
                    frmPub.ShowDialog(this);
                }
                else 
                {
                    MessageDialog.MensajeInformativo(this, "No puede realizar ninguna operación de compra u oferta hasta que califique todas sus operaciones");
                }
            }
        }


        #endregion

        #region [btn_Seleccionar_rubro]
        private void btn_Seleccionar_rubro_Click(object sender, EventArgs e)
        {
            Rubro rubro = null;
            using (ListadoRubros frm = new ListadoRubros())
            {
                frm.ShowDialog(this);
                rubro = frm.EntidadSeleccionada as Rubro;
            }

            if (rubro != null)
            {
                this.CargarRubro(rubro);
            }
        }

        private void CargarRubro(Rubro rubro)
        {
            this.rubroSeleccionado = rubro;
            this.tb_Rubro.Text = rubro.descripcion;
        }

        #endregion

        #region [KeyPressEvent]
        private void ListadoPublicacionesCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Salir();
            }
        }
        #endregion

        #region [btn_Salir]
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Metodos privados

        private Publicacion rearmarPublicacion(PublicacionAMostrar pubshow) {
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

        #region [Botonera de paginas]
        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                //Check if you are already at the last page.
                if (recNo == maxRec)
                {
                    MessageBox.Show("Ya se encuentra en la última página!");
                    return;
                }
            }
            this.Filtrar();
        }

        private void btn_Anterior_Click(object sender, EventArgs e)
        {
            if (currentPage == PageCount)
            {
                recNo = pageSize * (currentPage - 2);
            }
            currentPage -= 1;
            //Check if you are already at the first page.
            if (currentPage < 1)
            {
                MessageBox.Show("Ya se encuentra en la primer pagina!");
                currentPage = 1;
                return;
            }
            else
            {
                recNo = pageSize * (currentPage - 1);
            }
            this.Filtrar();
        }

        private void btn_Primer_pagina_Click(object sender, EventArgs e)
        {
            //Check if you are already at the first page.
            if (currentPage == 1)
            {
                MessageBox.Show("Ya se encuentra en la primer página!");
                return;
            }

            currentPage = 1;
            recNo = 0;
            this.Filtrar();
        }

        private void btn_Ultima_pagina_Click(object sender, EventArgs e)
        {
            //Check if you are already at the last page.
            if (recNo == maxRec)
            {
                MessageBox.Show("Ya se encuentra en la última página!");
                return;
            }
            currentPage = PageCount;
            recNo = pageSize * (currentPage - 1);
            this.Filtrar();
        }
        #endregion

    }
}
