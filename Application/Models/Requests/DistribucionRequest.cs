using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DistribucionRequest : IRequest<Distribucion>
    {
        public string NumeroDocumento { get; set; }
        public Distribucion ToEntity()
        {
            return new Distribucion();
        }
    }
}
