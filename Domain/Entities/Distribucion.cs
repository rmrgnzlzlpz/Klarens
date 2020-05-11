using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Distribucion : Entity<int>
    {
        public Vehiculo Vehiculo { get; set; }
        public Ruta Ruta { get; set; }
        public List<DistribucionVendedor> Vendedores { get; set; }
        public Conductor Conductor { get; set; }
        public List<DistribucionDetalle> DistribucionDetalles { get; set; }
    }
}