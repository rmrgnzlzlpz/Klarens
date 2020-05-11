using Domain.Base;

namespace Domain.Entities
{
    public class CompraDetalle : Entity<int>
    {
        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get => Cantidad * Precio; }
    }
}