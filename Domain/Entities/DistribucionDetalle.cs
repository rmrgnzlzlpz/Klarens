using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class DistribucionDetalle : Entity<int>
    {
        public Distribucion Distribucion { get; set; }
        public Venta Venta { get; set; }
    }
}