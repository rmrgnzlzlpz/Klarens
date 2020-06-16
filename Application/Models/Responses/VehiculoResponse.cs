using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class VehiculoResponse : Response<Vehiculo>
    {
        public VehiculoResponse(string mensaje) : base(mensaje)
        {
        }

        public VehiculoResponse(string mensaje, List<Vehiculo> entidades) : base(mensaje, entidades)
        {
        }

        public VehiculoResponse(string mensaje, Vehiculo entidad) : base(mensaje, entidad)
        {
        }
    }
}