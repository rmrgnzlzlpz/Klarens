using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class ProductoResponse : Response<Producto>
    {
        public ProductoResponse(string mensaje) : base(mensaje)
        {
        }

        public ProductoResponse(string mensaje, List<Producto> entidades) : base(mensaje, entidades)
        {
        }

        public ProductoResponse(string mensaje, Producto entidad) : base(mensaje, entidad)
        {
        }
    }
}