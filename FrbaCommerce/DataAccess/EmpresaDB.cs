using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;


namespace FrbaCommerce.DataAccess
{
    public class EmpresaDB
    {

        public decimal nuevoCliente(Empresa empresa)
        {

            IList<SqlParameter> parametros = this.GenerarParametrosCrear(empresa);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaEmpresa", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_usuario_agregado").FirstOrDefault();
            empresa.id_usuario = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return Convert.ToDecimal(idNuevoOUTPUT);
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
    }
}
