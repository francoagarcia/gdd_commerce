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

namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    public partial class RegistroDeUsuario : FormBaseSeleccionTipo
    {
        public RegistroDeUsuario() 
            : base(new ListaTipoUsuario() )
        {
        }

        protected override void CargarNombres()
        {
            this.Text = "Seleccion de tipo de usuario";
            this.groupBox_Tipo.Text = "Seleccione el tipo de usuario para continuar";
            this.label_Tipo.Text = "Tipo de usuario";
        }

        protected override void AccionMostrarSiguiente(TipoGenerico tipoElegido)
        {
            TipoUsuario tipo = (TipoUsuario)tipoElegido;
            if (tipo.Nombre.Equals("Empresa"))
                this.FormSiguiente = new RegistroDeEmpresa();
            else
                this.FormSiguiente = new RegistroDeCliente();
            this.mostrarVentanaSiguiente();
        }
    }
}
