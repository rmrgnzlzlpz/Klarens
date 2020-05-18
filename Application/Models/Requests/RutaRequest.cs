using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class RutaRequest : IRequest<Ruta>
    {
        public string NumeroDocumento { get; set; }
        public Ruta ToEntity()
        {
            return new Ruta();
        }
    }
}
