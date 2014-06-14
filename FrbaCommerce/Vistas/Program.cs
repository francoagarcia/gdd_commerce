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
                //12353	Descripcion Publicación212351	4	2013-01-06 00:00:00.000	2013-01-13 00:00:00.000	3116.56	1	1	10003	4	45	13	1
                Publicacion publicacion = new Publicacion();
                publicacion.descripcion = "asfdad";
                publicacion.precio = Convert.ToDecimal(10.00);
                publicacion.stock = Convert.ToDecimal(2.0);
                publicacion.tipo_publicacion = new TipoCompraInmediata();
                publicacion.fecha_inicio = DateManager.Ahora();
                publicacion.fecha_vencimiento = DateManager.Ahora();
                publicacion.habilitada = true;
                publicacion.permite_preguntas = true;
                EstadoPublicacion estado = new EstadoPublicacion();
                estado.id_estado = 1;
                estado.descripcion = "Publicada";
                publicacion.estado = estado;
                publicacion.rubro = new Rubro();
                publicacion.rubro.id_rubro =1;
                publicacion.rubro.descripcion = "Electrónica, Audio y Video";

                Application.Run(new FrbaCommerce.Vistas.Editar_Publicacion.ListadoPublicacionesDeVendedor());
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
