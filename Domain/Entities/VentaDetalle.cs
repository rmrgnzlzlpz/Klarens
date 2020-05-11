using Domain.Base;

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
    }
}