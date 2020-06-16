using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class VentaResponse : Response<Venta>
    {
        public VentaResponse(string mensaje) : base(mensaje)
        {
        }

        public VentaResponse(string mensaje, List<Venta> entidades) : base(mensaje, entidades)
        {
        }

        public VentaResponse(string mensaje, Venta entidad) : base(mensaje, entidad)
        {
        }
    }
}