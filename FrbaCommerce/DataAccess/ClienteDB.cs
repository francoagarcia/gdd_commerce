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

namespace FrbaCommerce.DataAccess
{
    public class ClienteDB : EntidadBaseDB<Cliente, FiltroCliente>
    {
        private UsuarioDB usuarioDB;

         public ClienteDB() 
            : base(new BuilderCliente(), "cliente") 
        {
            this.usuarioDB = new UsuarioDB();
        }

         public void inHabilitarCliente(Cliente clienteBaja)
         {
             this.usuarioDB.inHabilitarUsuario(clienteBaja);
         }

         public void habilitarCliente(Cliente clienteBaja)
         {
             this.usuarioDB.habilitarUsuario(clienteBaja);
         }

        public void modificarCliente(Cliente cliente) {
            IList<SqlParameter> parametros = this.GenerarParametrosModificar(cliente);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.modificarCliente", parametros);
        }

        public decimal nuevoCliente(Cliente clienteNuevo) {

            IList<SqlParameter> parametros = this.GenerarParametrosCrear(clienteNuevo);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevoCliente", parametros);
            
            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_usuario_agregado").FirstOrDefault();
            clienteNuevo.id_usuario = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return Convert.ToDecimal(idNuevoOUTPUT);
        }

        private IList<SqlParameter> GenerarParametrosModificar(Cliente clienteModificado) {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario_a_modificar = new SqlParameter("@id_usuario_a_modificar", System.Data.SqlDbType.Decimal, 18, "id_usuario");
            id_usuario_a_modificar.Value = clienteModificado.id_usuario;
            parametros.Add(id_usuario_a_modificar);

            SqlParameter id_tipo_documento = new SqlParameter("@id_tipo_documento", System.Data.SqlDbType.Decimal, 18, "id_tipo_documento");
            id_tipo_documento.Value = clienteModificado.tipo_documento.Id;
            parametros.Add(id_tipo_documento);

            SqlParameter nro_documento = new SqlParameter("@nro_documento", System.Data.SqlDbType.Decimal, 18, "nro_documento");
            nro_documento.Value = clienteModificado.nro_documento;
            parametros.Add(nro_documento);

            SqlParameter nombre_de_usuario = new SqlParameter("@nombre_de_usuario", System.Data.SqlDbType.NVarChar, 255, "username");
            nombre_de_usuario.Value = clienteModificado.username;
            parametros.Add(nombre_de_usuario);

            SqlParameter contrasenia_usuario = new SqlParameter("@contrasenia_usuario", System.Data.SqlDbType.NVarChar, 255, "contrasenia");
            contrasenia_usuario.Value = clienteModificado.contrasenia;
            parametros.Add(contrasenia_usuario);

            SqlParameter telefono_usuario = new SqlParameter("@telefono_usuario", System.Data.SqlDbType.Decimal, 18, "telefono");
            telefono_usuario.Value = clienteModificado.telefono;
            parametros.Add(telefono_usuario);

            SqlParameter nombre = new SqlParameter("@nombre", System.Data.SqlDbType.NVarChar, 255, "nombre");
            nombre.Value = clienteModificado.nombre;
            parametros.Add(nombre);

            SqlParameter apellido = new SqlParameter("@apellido", System.Data.SqlDbType.NVarChar, 255, "apellido");
            apellido.Value = clienteModificado.apellido;
            parametros.Add(apellido);

            SqlParameter dom_calle = new SqlParameter("@dom_calle", System.Data.SqlDbType.NVarChar, 255, "dom_calle");
            dom_calle.Value = clienteModificado.dom_calle;
            parametros.Add(dom_calle);

            SqlParameter piso = new SqlParameter("@piso", System.Data.SqlDbType.Decimal, 18, "piso");
            piso.Value = clienteModificado.piso;
            parametros.Add(piso);

            SqlParameter depto = new SqlParameter("@depto", System.Data.SqlDbType.NVarChar, 50, "depto");
            depto.Value = clienteModificado.depto;
            parametros.Add(depto);

            SqlParameter localidad = new SqlParameter("@localidad", System.Data.SqlDbType.NVarChar, 255, "localidad");
            localidad.Value = clienteModificado.localidad;
            parametros.Add(localidad);

            SqlParameter cod_postal = new SqlParameter("@cod_postal", System.Data.SqlDbType.NVarChar, 50, "cod_postal");
            cod_postal.Value = clienteModificado.cod_postal;
            parametros.Add(cod_postal);

            SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 255, "mail");
            mail.Value = clienteModificado.mail;
            parametros.Add(mail);

            SqlParameter fecha_nacimiento = new SqlParameter("@fecha_nacimiento", System.Data.SqlDbType.DateTime);
            fecha_nacimiento.SourceColumn = "fecha_nacimiento";
            fecha_nacimiento.Value = clienteModificado.fecha_nacimiento;
            parametros.Add(fecha_nacimiento);

            SqlParameter sexo = new SqlParameter("@sexo", System.Data.SqlDbType.Bit);
            sexo.SourceColumn = "sexo";
            sexo.Value = clienteModificado.sexo.Id;
            parametros.Add(sexo);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroCliente filtro)
        {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_tipo_documento = new SqlParameter("@id_tipo_doc", System.Data.SqlDbType.Decimal, 18, "id_tipo_documento");
            if (filtro.IdTipoDocumento != null)
                id_tipo_documento.Value = filtro.IdTipoDocumento.Id;
            parametros.Add(id_tipo_documento);

            SqlParameter nro_documento = new SqlParameter("@nro_documento", System.Data.SqlDbType.Decimal, 18, "nro_documento");
            if(filtro.NroDocumento.HasValue)
                nro_documento.Value = filtro.NroDocumento;
            parametros.Add(nro_documento);

            SqlParameter telefono = new SqlParameter("@telefono_usuario", System.Data.SqlDbType.Decimal, 18, "telefono");
            if(filtro.Telefono.HasValue)
                telefono.Value = filtro.Telefono;
            parametros.Add(telefono);

            SqlParameter nombre = new SqlParameter("@nombre", System.Data.SqlDbType.NVarChar, 255, "nombre");
            nombre.Value = filtro.Nombre;
            parametros.Add(nombre);

            SqlParameter apellido = new SqlParameter("@apellido", System.Data.SqlDbType.NVarChar, 255, "apellido");
            apellido.Value = filtro.Apellido;
            parametros.Add(apellido);

            SqlParameter dom_calle = new SqlParameter("@dom_calle", System.Data.SqlDbType.NVarChar, 255, "dom_calle");
            dom_calle.Value = filtro.Calle;
            parametros.Add(dom_calle);

            SqlParameter piso = new SqlParameter("@piso", System.Data.SqlDbType.Decimal, 18, "piso");
            if(filtro.Piso.HasValue)
                piso.Value = filtro.Piso;
            parametros.Add(piso);

            SqlParameter depto = new SqlParameter("@depto", System.Data.SqlDbType.NVarChar, 50, "depto");
            depto.Value = filtro.Depto;
            parametros.Add(depto);

            SqlParameter localidad = new SqlParameter("@localidad", System.Data.SqlDbType.NVarChar, 255, "localidad");
            if(!string.IsNullOrEmpty(filtro.Localidad))
                localidad.Value = filtro.Localidad;
            parametros.Add(localidad);

            SqlParameter cod_postal = new SqlParameter("@cod_postal", System.Data.SqlDbType.NVarChar, 50, "cod_postal");
            cod_postal.Value = filtro.CodigoPostal;
            parametros.Add(cod_postal);

            SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 255, "mail");
            mail.Value = filtro.Mail;
            parametros.Add(mail);

            SqlParameter fecha_nacimiento = new SqlParameter("@fecha_nacimiento", System.Data.SqlDbType.DateTime);
            if (filtro.FechaDeNacimiento.HasValue)
                fecha_nacimiento.Value = filtro.FechaDeNacimiento;
            fecha_nacimiento.SourceColumn = "fecha_nacimiento";
            parametros.Add(fecha_nacimiento);

            SqlParameter habilitada = new SqlParameter("@habilitada", System.Data.SqlDbType.Bit);
            habilitada.SourceColumn = "habilitada";
            if(filtro.Habilitada.HasValue)
                habilitada.Value = filtro.Habilitada;
            parametros.Add(habilitada);

            SqlParameter sexo = new SqlParameter("@sexo", System.Data.SqlDbType.Bit);
            sexo.SourceColumn = "sexo";
            if (filtro.IdSexo != null)
                sexo.Value = filtro.IdSexo.Id;
            parametros.Add(sexo);

            return parametros;
        }

        private IList<SqlParameter> GenerarParametrosCrear(Cliente clienteNuevo) {

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
