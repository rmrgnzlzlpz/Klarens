using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class DistribucionVendedor : BaseEntity
    {
        public int DistribucionId { get; set; }
        public Distribucion Distribucion { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}