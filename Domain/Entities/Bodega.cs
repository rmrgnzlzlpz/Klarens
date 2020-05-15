using System.Collections.Generic;
using System.Linq;
using Domain.Base;

namespace Domain.Entities
{
    public class Bodega : Entity<int>
    {
        private static List<string> _errores;
        public List<ProductoBodega> ProductoBodegas { get; private set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public BodegaTipo Tipo { get; set; }
        public BodegaEstado Estado { get; set; }
        
        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (PuedeAgregarProducto(producto, cantidad).Any()) throw new System.Exception(string.Join(",", _errores));

            ProductoBodegas.Add(new ProductoBodega {
                Producto = producto,
                Cantidad = cantidad
            });
        }

        public static List<string> PuedeAgregarProducto(Producto producto, int cantidad)
        {
            _errores = new List<string>();
            if (cantidad < 1) _errores.Add("La cantidad del producto debe ser mayor a 0.");
            if (producto == null) _errores.Add("Producto no válido.");
            return _errores;
        }
    }

    public enum BodegaEstado
    {
        Inactiva = 0, Activa = 1
    }

    public enum BodegaTipo
    {
        Principal = 0, Secundaria = 1, Movil = 2
    }
}