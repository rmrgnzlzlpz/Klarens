using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class ProveedorRequest : IRequest<Proveedor>
    {
        public string NumeroDocumento { get; set; }
        public Proveedor ToEntity()
        {
            return new Proveedor();
        }
    }
}
