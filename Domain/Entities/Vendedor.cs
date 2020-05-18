using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;

namespace Domain.Entities
{
    public class Vendedor : Entity<int>
    {
        public Persona Persona { get; set; }
        public List<Venta> Ventas { get; set; }
        public double VendidoMes
        {
            get
            {
                if (Ventas == null) return 0;
                double total = 0;
                foreach (var venta in Ventas.Where(x => x.Fecha.Month == DateTime.UtcNow.Month))
                {
                    total += venta.Total;
                }
                return total;
            }
        }
    }
}