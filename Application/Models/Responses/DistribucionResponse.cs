using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DistribucionResponse : Response<Distribucion>
    {
        public DistribucionResponse(string mensaje) : base(mensaje)
        {
        }

        public DistribucionResponse(string mensaje, List<Distribucion> entidades) : base(mensaje, entidades)
        {
        }

        public DistribucionResponse(string mensaje, Distribucion entidad) : base(mensaje, entidad)
        {
        }
    }
}