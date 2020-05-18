using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DevolucionRequest : IRequest<Devolucion>
    {
        public string NumeroDocumento { get; set; }
        public Devolucion ToEntity()
        {
            return new Devolucion();
        }
    }
}
