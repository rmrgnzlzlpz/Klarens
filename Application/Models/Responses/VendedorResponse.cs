using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class VendedorResponse : Response<Vendedor>
    {
        public VendedorResponse(string mensaje) : base(mensaje)
        {
        }

        public VendedorResponse(string mensaje, List<Vendedor> entidades) : base(mensaje, entidades)
        {
        }

        public VendedorResponse(string mensaje, Vendedor entidad) : base(mensaje, entidad)
        {
        }
    }
}