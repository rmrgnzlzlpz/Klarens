using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class RutaResponse : Response<Ruta>
    {
        public RutaResponse(string mensaje) : base(mensaje)
        {
        }

        public RutaResponse(string mensaje, List<Ruta> entidades) : base(mensaje, entidades)
        {
        }

        public RutaResponse(string mensaje, Ruta entidad) : base(mensaje, entidad)
        {
        }
    }
}