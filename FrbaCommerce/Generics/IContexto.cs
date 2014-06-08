using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics;
using FrbaCommerce.Generics.Logger;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Generics
{
    public interface IContexto
    {
        string LogPath { get; }
        ILogger Logger { get; }
        DateTime FechaActual { get; }

        Usuario UsuarioActual { get; }
        Rol RolActual { get; }

        void RegistrarUsuario(Usuario usuario);
        void RegistrarRol(Rol rol);

        void DesregistrarUsuario();
        void DesregistrarRol();

        bool SesionIniciada { get; }
    }
}
