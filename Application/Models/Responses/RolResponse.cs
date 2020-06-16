using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class RolResponse : Response<Rol>
    {
        public RolResponse(string mensaje) : base(mensaje)
        {
        }

        public RolResponse(string mensaje, List<Rol> entidades) : base(mensaje, entidades)
        {
        }

        public RolResponse(string mensaje, Rol entidad) : base(mensaje, entidad)
        {
        }
    }
}