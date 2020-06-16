using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DeudaResponse : Response<Deuda>
    {
        public DeudaResponse(string mensaje) : base(mensaje)
        {
        }

        public DeudaResponse(string mensaje, List<Deuda> entidades) : base(mensaje, entidades)
        {
        }

        public DeudaResponse(string mensaje, Deuda entidad) : base(mensaje, entidad)
        {
        }
    }
}