using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class RolRequest : IRequest<Rol>
    {
        public string NumeroDocumento { get; set; }
        public Rol ToEntity()
        {
            return new Rol();
        }
    }
}
