using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DevolucionResponse : Response<Devolucion>
    {
        public DevolucionResponse(string mensaje) : base(mensaje)
        {
        }

        public DevolucionResponse(string mensaje, List<Devolucion> entidades) : base(mensaje, entidades)
        {
        }

        public DevolucionResponse(string mensaje, Devolucion entidad) : base(mensaje, entidad)
        {
        }
    }
}