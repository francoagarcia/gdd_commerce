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

namespace FrbaCommerce.DataAccess
{
    public class ClienteDB
    {

        public static decimal nuevoCliente(Cliente clienteNuevo) {

            IList<SqlParameter> parametros = ClienteDB.GenerarParametrosCrear(clienteNuevo);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevoCliente", parametros);
            
            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_usuario_agregado").FirstOrDefault();
            clienteNuevo.id_usuario = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return Convert.ToDecimal(idNuevoOUTPUT);
        }

        public static bool existeDocumentoRepetidoDeCliente(TipoDocumento tipoDoc, decimal nro_documento) {

            return true;
        }

        private static IList<SqlParameter> GenerarParametrosCrear(Cliente clienteNuevo) {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario_agregado = new SqlParameter("@id_usuario_agregado", System.Data.SqlDbType.Decimal, 18, "id_usuario");
            id_usuario_agregado.Direction =  System.Data.ParameterDirection.Output;
            parametros.Add(id_usuario_agregado);

            SqlParameter id_tipo_documento = new SqlParameter("@id_tipo_doc", System.Data.SqlDbType.Decimal, 18, "id_tipo_documento");
            id_tipo_documento.Value = clienteNuevo.tipo_documento.Id;
            parametros.Add(id_tipo_documento);

            SqlParameter nro_documento = new SqlParameter("@nro_documento", System.Data.SqlDbType.Decimal, 18, "nro_documento");
            nro_documento.Value = clienteNuevo.nro_documento;
            parametros.Add(nro_documento);

            SqlParameter username = new SqlParameter("@nombre_de_usuario", System.Data.SqlDbType.NVarChar, 255, "username");
            username.Value = clienteNuevo.username;
            parametros.Add(username);

            SqlParameter contrasenia = new SqlParameter("@contrasenia_usuario", System.Data.SqlDbType.NVarChar, 255, "contrasenia");
            contrasenia.Value = clienteNuevo.contrasenia;
            parametros.Add(contrasenia);

            SqlParameter telefono = new SqlParameter("@telefono_usuario", System.Data.SqlDbType.Decimal, 18, "telefono");
            telefono.Value = clienteNuevo.telefono;
            parametros.Add(telefono);

            SqlParameter nombre = new SqlParameter("@nombre", System.Data.SqlDbType.NVarChar, 255, "nombre");
            nombre.Value = clienteNuevo.nombre;
            parametros.Add(nombre);

            SqlParameter apellido = new SqlParameter("@apellido", System.Data.SqlDbType.NVarChar, 255, "apellido");
            apellido.Value = clienteNuevo.apellido;
            parametros.Add(apellido);

            SqlParameter dom_calle = new SqlParameter("@dom_calle", System.Data.SqlDbType.NVarChar, 255, "dom_calle");
            dom_calle.Value = clienteNuevo.dom_calle;
            parametros.Add(dom_calle);

            SqlParameter piso = new SqlParameter("@piso", System.Data.SqlDbType.Decimal, 18, "piso");
            piso.Value = clienteNuevo.piso;
            parametros.Add(piso);

            SqlParameter depto = new SqlParameter("@depto", System.Data.SqlDbType.NVarChar, 50, "depto");
            depto.Value = clienteNuevo.depto;
            parametros.Add(depto);

            SqlParameter localidad = new SqlParameter("@localidad", System.Data.SqlDbType.NVarChar, 255, "localidad");
            localidad.Value = clienteNuevo.localidad;
            parametros.Add(localidad);

            SqlParameter cod_postal = new SqlParameter("@cod_postal", System.Data.SqlDbType.NVarChar, 50, "cod_postal");
            cod_postal.Value = clienteNuevo.cod_postal;
            parametros.Add(cod_postal);

            SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 255, "mail");
            mail.Value = clienteNuevo.mail;
            parametros.Add(mail);

            SqlParameter fecha_nacimiento = new SqlParameter("@fecha_nacimiento", System.Data.SqlDbType.DateTime);
            fecha_nacimiento.SourceColumn = "fecha_nacimiento";
            fecha_nacimiento.Value = clienteNuevo.fecha_nacimiento;
            parametros.Add(fecha_nacimiento);

            SqlParameter sexo = new SqlParameter("@sexo", System.Data.SqlDbType.Bit);
            sexo.SourceColumn = "sexo";
            sexo.Value = clienteNuevo.sexo.Id;
            parametros.Add(sexo);

            return parametros;
        }


    }
}
