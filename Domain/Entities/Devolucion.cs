using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Devolucion : Entity<int>
    {
        public Venta Venta { get; set; }
        public List<DevolucionDetalle> DevolucionDetalles { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public DevolucionEstado Estado { get; set; }
        public string Descripcion { get; set; }

        public Devolucion(Venta venta, List<DevolucionDetalle> detalles)
        {
            Venta = venta;
            DevolucionDetalles = detalles;
        }

        public Devolucion() { }
    }

    public enum DevolucionEstado
    {
    }
}