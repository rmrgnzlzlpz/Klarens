using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class ProveedorResponse : Response<Proveedor>
    {
        public ProveedorResponse(string mensaje) : base(mensaje)
        {
        }

        public ProveedorResponse(string mensaje, List<Proveedor> entidades) : base(mensaje, entidades)
        {
        }

        public ProveedorResponse(string mensaje, Proveedor entidad) : base(mensaje, entidad)
        {
        }
    }
}