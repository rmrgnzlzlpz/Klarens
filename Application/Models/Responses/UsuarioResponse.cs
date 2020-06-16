using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class UsuarioResponse : Response<Usuario>
    {
        public UsuarioResponse(string mensaje) : base(mensaje)
        {
        }

        public UsuarioResponse(string mensaje, List<Usuario> entidades) : base(mensaje, entidades)
        {
        }

        public UsuarioResponse(string mensaje, Usuario entidad) : base(mensaje, entidad)
        {
        }
    }
}