using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using FrbaCommerce.Generics.Logger;
using FrbaCommerce.Generics;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.Vistas.Login;
using FrbaCommerce.Vistas.Historial_Cliente;
using FrbaCommerce.Vistas.Listado_Estadistico;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.Vistas.Gestion_de_Preguntas;
using FrbaCommerce.Vistas.Comprar_Ofertar;

namespace FrbaCommerce
{
    static class Program
    {
        public static IContexto ContextoActual { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = AppConfigReader.Get("log_path");
            string filename = Path.Combine(path, string.Format("{0}.log", DateTime.Now.ToString("yyyyMMddhhmmss")));

            ContextoActual = new ContextoAplicacion(filename, DateManager.Ahora());



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                ContextoActual.Logger.Iniciar();

                Usuario usu = new Usuario();
                usu.username = "33354435";
                usu.id_usuario = 1;
                usu.habilitada = true;
                Application.Run(new FrbaCommerce.Vistas.Facturar_Publicaciones.FacturarPublicaciones());
                //Application.Run(new FrbaCommerce.Vistas.Facturar_Publicaciones.ListadoUsuarios());

            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError("Ha ocurrido un error fatal. Revise el archivo de log para obtener más información al respecto.");
                ContextoActual.Logger.Log(ex);
            }
            finally
            {
                ContextoActual.Logger.Finalizar();
            }
        }
    }
}
