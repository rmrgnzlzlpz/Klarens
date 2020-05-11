using System.Collections.Generic;
using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Vehiculo : Entity<int>
    {
        public Bodega Bodega { get; set; }
        public Comprobante Comprobante { get; set; }
    }
}