using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Vistas.Generar_Publicacion
{
    public partial class SeleccionTipoPublicacion : FormBaseSeleccionTipo
    {
        protected Usuario usuarioPublicador;

        public SeleccionTipoPublicacion(Usuario unUsuario)
            : base(new ListaTipoPublicacion())
        {
            this.usuarioPublicador = unUsuario;
            InitializeComponent();
        }

        protected override void CargarNombres()
        {
            this.Text = "Seleccion de tipo de publicacion";
            this.groupBox_Tipo.Text = "Seleccione el tipo de publicacion para continuar";
            this.label_Tipo.Text = "Tipo de publicacion";
        }

        protected override void AccionMostrarSiguiente(TipoGenerico tipoElegido)
        {
            TipoPublicacion tipo = (TipoPublicacion)tipoElegido;
            if (!string.IsNullOrEmpty(tipo.Nombre))
            {
                this.FormSiguiente = new GenerarPublicacion(tipo, this.usuarioPublicador);
                this.mostrarVentanaSiguiente();
            }
            else
                MessageDialog.MensajeInformativo(this, "Seleccione un tipo de publicacion a crear para continuar");
        }
    }
}
