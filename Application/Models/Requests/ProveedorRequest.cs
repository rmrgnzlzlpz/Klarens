using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class ProveedorRequest : Request<Proveedor>
    {
        public string NumeroDocumento { get; set; }
        public override Proveedor ToEntity()
        {
            return new Proveedor();
        }
    }
}
