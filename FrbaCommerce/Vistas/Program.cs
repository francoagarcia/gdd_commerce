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
<<<<<<< HEAD
            Application.Run(new Historial());
=======

            try
            {
                ContextoActual.Logger.Iniciar();
                Application.Run(new Inicio());
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
>>>>>>> 23f8a3944da9304ebbe7f4bd047e4c5901338cba
        }
    }
}
