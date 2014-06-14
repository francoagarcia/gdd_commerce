using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderPublicacion : IBuilder<Publicacion>
    {
        public Publicacion Build(System.Data.DataRow row) {

            Publicacion publi = new Publicacion();
            publi.id_publicacion = Convert.ToDecimal(row["id_publicacion"]);
            publi.descripcion = Convert.ToString(row["descripcion"]);
            publi.fecha_inicio = Convert.ToDateTime(row["fecha_inicio"]);
            publi.fecha_vencimiento = Convert.ToDateTime(row["fecha_vencimiento"]);
            publi.habilitada = Convert.ToBoolean(row["habilitada"]);
            publi.permite_preguntas = Convert.ToBoolean(row["permite_preguntas"]);
            publi.precio = Convert.ToDecimal(row["precio"]);
            publi.stock = Convert.ToDecimal(row["stock"]);
            publi.estado = this.BuildEstado(row);
            publi.rubro = this.BuildRubro(row);
            publi.tipo_publicacion = this.BuildTipoPublicacion(row);
            publi.visibilidad = this.BuildVisibilidad(row);

            return publi;
        }

        private Visibilidad BuildVisibilidad(System.Data.DataRow row) {
            Visibilidad visi = new Visibilidad();
            visi.id_visibilidad = Convert.ToDecimal(row["id_visibilidad"]);
            visi.descripcion = Convert.ToString(row["descVisi"]);
            return visi;
        }

        private TipoPublicacion BuildTipoPublicacion(System.Data.DataRow row) {
            TipoPublicacion tipo = new TipoPublicacion();
            tipo.Id = Convert.ToInt32(row["id_tipo_publicacion"]);
            tipo.Nombre = Convert.ToString(row["descTipoPubli"]);
            return tipo;
        }

        private Rubro BuildRubro(System.Data.DataRow row) {
            Rubro rubro = new Rubro();
            rubro.id_rubro = Convert.ToDecimal(row["id_rubro"]);
            rubro.descripcion = Convert.ToString(row["descRubro"]);
            return rubro;
        }

        private EstadoPublicacion BuildEstado(System.Data.DataRow row)
        {
            EstadoPublicacion estado = new EstadoPublicacion();
            estado.id_estado = Convert.ToDecimal(row["id_estado"]);
            estado.descripcion = Convert.ToString(row["descEstado"]);
            return estado;
        }
    }
}
