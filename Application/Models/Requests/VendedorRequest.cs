using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class VendedorRequest : Request<Vendedor>
    {
        public string NumeroDocumento { get; set; }
        public override Vendedor ToEntity()
        {
            return new Vendedor();
        }
    }
}
