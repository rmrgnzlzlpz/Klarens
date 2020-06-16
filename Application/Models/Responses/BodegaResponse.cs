using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class BodegaResponse : Response<Bodega>
    {
        public BodegaResponse(string mensaje) : base(mensaje)
        {
        }

        public BodegaResponse(string mensaje, List<Bodega> entidades) : base(mensaje, entidades)
        {
        }

        public BodegaResponse(string mensaje, Bodega entidad) : base(mensaje, entidad)
        {
        }
    }
}