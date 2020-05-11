using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Ruta : Entity<int>
    {
        public List<Distribucion> Distribuciones { get; set; }
    }
}