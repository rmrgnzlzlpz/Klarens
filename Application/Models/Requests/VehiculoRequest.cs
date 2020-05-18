using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class VehiculoRequest : IRequest<Vehiculo>
    {
        public string NumeroDocumento { get; set; }
        public Vehiculo ToEntity()
        {
            return new Vehiculo();
        }
    }
}
