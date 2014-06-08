using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FrbaCommerce.Generics.Logger
{
    public class LoggerFile : ILogger
    {
        #region Atributos
        private StreamWriter _stream;
        public string FilePath { get; set; }
        #endregion

        #region Constructor
        public LoggerFile(string path)
        {
            FilePath = path;
        }
        #endregion

        #region ILog

        public void Log(string mensaje)
        {
            EscribirLinea(mensaje);
        }

        public void Log(Exception ex)
        {
            EscribirLinea(ex.Message);
            EscribirLinea(ex.StackTrace);
        }

        public void Iniciar()
        {
            _stream = File.CreateText(FilePath);
            EscribirLinea("Inicio del registro de actividad");
        }

        public void Finalizar()
        {
            EscribirLinea("Fin del registro de actividad");
            _stream.Flush();
            _stream.Close();
        }

        #endregion

        #region Métodos privados
        private void EscribirLinea(string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} - {1}", DateManager.Format(DateManager.Ahora()), mensaje);
            _stream.WriteLine(sb.ToString());
        }
        #endregion
    }
}
