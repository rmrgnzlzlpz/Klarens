using Domain.Base;
using System;

namespace Domain.Entities
{
    public class VentaDetalle : Entity<int>
    {
        public Venta Venta { get; set; }
        public ProductoBodega ProductoBodega { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public double Total { get => Precio * Cantidad - Descuento; }

        public void Aumentar(int cantidad, double precio, double descuento)
        {
            Precio = (Precio * Cantidad + precio * cantidad) / (Cantidad + cantidad);
            Cantidad += cantidad;
            Descuento += descuento;
        }
    }
}