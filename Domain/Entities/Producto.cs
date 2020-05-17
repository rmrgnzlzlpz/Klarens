using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Producto : Entity<int>
    {
        public Subcategoria Subcategoria { get; set; }
        public List<ProductoBodega> ProductoBodegas { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get {
            if (ProductoBodegas == null) return 0;
            int total = 0;
            foreach (var producto in ProductoBodegas)
            {
                total += producto.Cantidad;
            }
            return total;
        }}
        public string Descripcion { get; set; }
        public ProductoEstado Estado { get; set; }

        public Producto()
        {
        }
    }

    public enum ProductoEstado
    {
        Inactivo = 0, Activo = 1
    }
}