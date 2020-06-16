using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class CompraResponse : Response<Compra>
    {
        public CompraResponse(string mensaje) : base(mensaje)
        {
        }

        public CompraResponse(string mensaje, List<Compra> entidades) : base(mensaje, entidades)
        {
        }

        public CompraResponse(string mensaje, Compra entidad) : base(mensaje, entidad)
        {
        }
    }
}