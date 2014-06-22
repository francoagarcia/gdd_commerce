using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.DataAccess;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    public partial class GestionPregunta : Form
    {
        public PreguntasDB preguntasDB;
        public Usuario usuario;

        public GestionPregunta(Usuario usu)
        {
            this.usuario = usu;
            this.preguntasDB = new PreguntasDB();

            InitializeComponent();
      
        }

        #region [EventoLoad]
        private void GestionPregunta_Load(object sender, EventArgs e)
        {
            // Cargo las respuestas que ya se realizaron

            DataSet dp = this.preguntasDB.dame_Respuestas(this.usuario);

            dg_respuestas.AutoGenerateColumns = true;
            dg_respuestas.DataSource = dp.Tables[0];
        }
        #endregion

        #region [Aceptar]
        private void btn_responder_Click(object sender, EventArgs e)
        {
             AltaRespuesta frm = new AltaRespuesta(this.usuario);
            
             frm.ShowDialog(frm);
            
        }
        #endregion 

        #region [Cancelar]
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

      
    }
}
