using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.Generics.Excepciones;

namespace FrbaCommerce.DataAccess
{
    public class EmpresaDB : EntidadBaseDB<Empresa, FiltroEmpresa>
    {
        private UsuarioDB usuarioDB;

        public EmpresaDB() 
            :base(new BuilderEmpresa(), "empresa") //Esto es para los filtros
        {
            this.usuarioDB = new UsuarioDB();
        }

        public void inHabilitarEmpresa(Empresa empresaBaja)
        {
            this.usuarioDB.inHabilitarUsuario(empresaBaja);
        }

        public void habilitarEmpresa(Empresa empresaBaja)
        {
            this.usuarioDB.habilitarUsuario(empresaBaja);
        }

        public void modificarEmpresa(Empresa empresa) {
            IList<SqlParameter> parametros = this.GenerarParametrosModificar(empresa);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.modificarEmpresa", parametros);
        }

        public decimal nuevaEmpresa(Empresa empresa)
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(empresa);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaEmpresa", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_usuario_agregado").FirstOrDefault();
             if (idNuevoOUTPUT.Value != System.DBNull.Value)
            {
                empresa.id_usuario = Convert.ToDecimal(idNuevoOUTPUT.Value);
                return empresa.id_usuario;
            }
            else
            {
                throw new TelefonoRepetidoException();
            }
        }

        #region Generadores de parametros
        private IList<SqlParameter> GenerarParametrosModificar(Empresa empresa)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario_a_modificar = new SqlParameter("@id_usuario_a_modificar", System.Data.SqlDbType.Decimal, 18, "id_usuario");
            id_usuario_a_modificar.Value = empresa.id_usuario;
            parametros.Add(id_usuario_a_modificar);

            SqlParameter CUIT = new SqlParameter("@cuit", System.Data.SqlDbType.NVarChar, 50, "cuit");
            CUIT.Value = empresa.cuit;
            parametros.Add(CUIT);

            SqlParameter razon_social = new SqlParameter("@razon_social", System.Data.SqlDbType.NVarChar, 255, "razon_social");
            razon_social.Value = empresa.razon_social;
            parametros.Add(razon_social);

            SqlParameter username = new SqlParameter("@nombre_de_usuario", System.Data.SqlDbType.NVarChar, 255, "username");
            username.Value = empresa.username;
            parametros.Add(username);

            SqlParameter contrasenia = new SqlParameter("@contrasenia_usuario", System.Data.SqlDbType.NVarChar, 255, "contrasenia");
            contrasenia.Value = empresa.contrasenia;
            parametros.Add(contrasenia);

            SqlParameter telefono = new SqlParameter("@telefono_usuario", System.Data.SqlDbType.Decimal, 18, "telefono");
            telefono.Value = empresa.telefono;
            parametros.Add(telefono);

            SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 255, "mail");
            mail.Value = empresa.mail;
            parametros.Add(mail);

            SqlParameter dom_calle = new SqlParameter("@dom_calle", System.Data.SqlDbType.NVarChar, 255, "dom_calle");
            dom_calle.Value = empresa.dom_calle;
            parametros.Add(dom_calle);

            SqlParameter nro_calle = new SqlParameter("@nro_calle", System.Data.SqlDbType.Decimal, 18, "nro_calle");
            nro_calle.Value = empresa.altura;
            parametros.Add(nro_calle);

            SqlParameter piso = new SqlParameter("@piso", System.Data.SqlDbType.Decimal, 18, "piso");
            piso.Value = empresa.piso;
            parametros.Add(piso);

            SqlParameter depto = new SqlParameter("@depto", System.Data.SqlDbType.NVarChar, 50, "depto");
            depto.Value = empresa.depto;
            parametros.Add(depto);

            SqlParameter localidad = new SqlParameter("@localidad", System.Data.SqlDbType.NVarChar, 255, "localidad");
            localidad.Value = empresa.localidad;
            parametros.Add(localidad);

            SqlParameter cod_postal = new SqlParameter("@cod_postal", System.Data.SqlDbType.NVarChar, 50, "cod_postal");
            cod_postal.Value = empresa.cod_postal;
            parametros.Add(cod_postal);

            SqlParameter ciudad = new SqlParameter("@ciudad", System.Data.SqlDbType.NVarChar, 255, "ciudad");
            ciudad.Value = empresa.ciudad;
            parametros.Add(ciudad);

            SqlParameter nombre_de_contacto = new SqlParameter("@nombre_de_contacto", System.Data.SqlDbType.NVarChar, 255, "nombre_de_contacto");
            nombre_de_contacto.Value = empresa.nombre_de_contacto;
            parametros.Add(nombre_de_contacto);

            SqlParameter fecha_nacimiento = new SqlParameter("@fecha_creacion", System.Data.SqlDbType.DateTime);
            fecha_nacimiento.SourceColumn = "fecha_creacion";
            fecha_nacimiento.Value = empresa.fecha_creacion;
            parametros.Add(fecha_nacimiento);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroEmpresa entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter CUIT = new SqlParameter("@CUIT", System.Data.SqlDbType.NVarChar, 50, "cuit");
            if (!string.IsNullOrEmpty(entidad.CUIT))
                CUIT.Value = entidad.CUIT;
            parametros.Add(CUIT);

            SqlParameter razon_social = new SqlParameter("@razon_social", System.Data.SqlDbType.NVarChar, 255, "razon_social");
            razon_social.Value = entidad.razon_social;
            parametros.Add(razon_social);

            SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 50, "mail");
            mail.Value = entidad.mail;
            parametros.Add(mail);

            SqlParameter habilitada = new SqlParameter("@habilitada", System.Data.SqlDbType.Bit);
            habilitada.SourceColumn = "habilitada";
            if (entidad.habilitada.HasValue)
                habilitada.Value = entidad.habilitada;
            parametros.Add(habilitada);

            return parametros;
        }

        private IList<SqlParameter> GenerarParametrosCrear(Empresa empresa)
        {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario_agregado = new SqlParameter("@id_usuario_agregado", System.Data.SqlDbType.Decimal, 18, "id_usuario");
            id_usuario_agregado.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(id_usuario_agregado);

            SqlParameter username = new SqlParameter("@nombre_de_usuario", System.Data.SqlDbType.NVarChar, 255, "username");
            username.Value = empresa.username;
            parametros.Add(username);

            SqlParameter contrasenia = new SqlParameter("@contrasenia_usuario", System.Data.SqlDbType.NVarChar, 255, "contrasenia");
            contrasenia.Value = empresa.contrasenia;
            parametros.Add(contrasenia);

            SqlParameter telefono = new SqlParameter("@telefono_usuario", System.Data.SqlDbType.Decimal, 18, "telefono");
            telefono.Value = empresa.telefono;
            parametros.Add(telefono);

            SqlParameter CUIT = new SqlParameter("@cuit", System.Data.SqlDbType.NVarChar, 50, "cuit");
            CUIT.Value = empresa.cuit;
            parametros.Add(CUIT);

            SqlParameter razon_social = new SqlParameter("@razon_social", System.Data.SqlDbType.NVarChar, 255, "razon_social");
            razon_social.Value = empresa.razon_social;
            parametros.Add(razon_social);

            SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 255, "mail");
            mail.Value = empresa.mail;
            parametros.Add(mail);

            SqlParameter dom_calle = new SqlParameter("@dom_calle", System.Data.SqlDbType.NVarChar, 255, "dom_calle");
            dom_calle.Value = empresa.dom_calle;
            parametros.Add(dom_calle);

            SqlParameter nro_calle = new SqlParameter("@nro_calle", System.Data.SqlDbType.Decimal, 18, "nro_calle");
            nro_calle.Value = empresa.altura;
            parametros.Add(nro_calle);

            SqlParameter piso = new SqlParameter("@piso", System.Data.SqlDbType.Decimal, 18, "piso");
            piso.Value = empresa.piso;
            parametros.Add(piso);

            SqlParameter depto = new SqlParameter("@depto", System.Data.SqlDbType.NVarChar, 50, "depto");
            depto.Value = empresa.depto;
            parametros.Add(depto);

            SqlParameter localidad = new SqlParameter("@localidad", System.Data.SqlDbType.NVarChar, 255, "localidad");
            localidad.Value = empresa.localidad;
            parametros.Add(localidad);

            SqlParameter cod_postal = new SqlParameter("@cod_postal", System.Data.SqlDbType.NVarChar, 50, "cod_postal");
            cod_postal.Value = empresa.cod_postal;
            parametros.Add(cod_postal);

            SqlParameter ciudad = new SqlParameter("@ciudad", System.Data.SqlDbType.NVarChar, 255, "ciudad");
            ciudad.Value = empresa.ciudad;
            parametros.Add(ciudad);

            SqlParameter nombre_de_contacto = new SqlParameter("@nombre_de_contacto", System.Data.SqlDbType.NVarChar, 255, "nombre_de_contacto");
            nombre_de_contacto.Value = empresa.nombre_de_contacto;
            parametros.Add(nombre_de_contacto);

            SqlParameter fecha_nacimiento = new SqlParameter("@fecha_creacion", System.Data.SqlDbType.DateTime);
            fecha_nacimiento.SourceColumn = "fecha_creacion";
            fecha_nacimiento.Value = empresa.fecha_creacion;
            parametros.Add(fecha_nacimiento);

            return parametros;
        }

        #endregion
    }
}
