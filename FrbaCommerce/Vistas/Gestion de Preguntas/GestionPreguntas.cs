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

namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    public partial class GestionPreguntas : FormBase
    {
        public GestionPreguntas()
        {
            InitializeComponent();
        }

        

        private void GestionPreguntas_Load(object sender, EventArgs e)
        {
        }

        

        private void btn_Ver_preguntas_pendientes_Click(object sender, EventArgs e)
        {
            this.CargarPreguntasPendientes();
        }

        private void CargarPreguntasPendientes() 
        { 
        
        }

        private void btn_Ver_respuestas_Click(object sender, EventArgs e)
        {
            this.CargarRespuestasHechas();
        }

        private void CargarRespuestasHechas() 
        { 
        
        }

        #region [Salir]
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
