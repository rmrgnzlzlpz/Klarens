using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class ConductorResponse : Response<Conductor>
    {
        public ConductorResponse(string mensaje) : base(mensaje)
        {
        }

        public ConductorResponse(string mensaje, List<Conductor> entidades) : base(mensaje, entidades)
        {
        }

        public ConductorResponse(string mensaje, Conductor entidad) : base(mensaje, entidad)
        {
        }
    }
}