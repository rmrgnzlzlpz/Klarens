using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;

namespace Domain.Entities
{
    public class Vendedor : Entity<int>
    {
        public Persona Persona { get; private set; }
        public Usuario Usuario { get; private set; }
        public List<Venta> Ventas { get; set; }
        public double VendidoMes
        {
            get
            {
                DateTime inicio = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 0);
                return TotalVendido(inicio, DateTime.UtcNow);
            }
        }

        public double TotalVendido(DateTime fechaInicio, DateTime fechaFinal)
        {
            double total = 0;
            if (Ventas != null)
            {
                Ventas.Where(x => x.Fecha < fechaInicio && x.Fecha > fechaFinal).ToList().ForEach(x => {
                    total += x.Total;
                });
            }
            return total;
        }
        
        public Vendedor() {}

        public Vendedor(Persona persona, Usuario usuario)
        {
            Persona = persona;
            Usuario = usuario;
        }
    }
}