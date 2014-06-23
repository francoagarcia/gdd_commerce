using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades.Filtros
{
    public class FiltroCliente
    {
        public TipoDocumento IdTipoDocumento { get; set; }
        public decimal? IdUsuario { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal? Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public Sexo IdSexo { get; set; }
        public string Calle { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Depto { get; set; }
        public decimal? Piso { get; set; }
        public bool? Habilitada { get; set; }
    }
}
