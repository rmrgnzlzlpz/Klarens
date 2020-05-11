using Domain.Base;

namespace Domain.Entities
{
    public class DevolucionDetalle : Entity<int>
    {
        public Devolucion Devolucion { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}