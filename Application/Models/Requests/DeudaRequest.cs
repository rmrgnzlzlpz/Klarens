using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DeudaRequest : IRequest<Deuda>
    {
        public string NumeroDocumento { get; set; }
        public Deuda ToEntity()
        {
            return new Deuda();
        }
    }
}
