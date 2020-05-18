using System.Collections.Generic;
using System.Linq;
using Domain.Base;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Bodega : Entity<int>, IBodega
    {
        private static List<string> _errores;
        public IList<ProductoBodega> ProductoBodegas { get; private set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public BodegaTipo Tipo { get; set; }
        public BodegaEstado Estado { get; set; }

        public bool ExisteProducto(Producto producto)
        {
            return ProductoBodegas.FirstOrDefault(x => x.Producto == producto) != null;
        }

        public ProductoBodega AgregarProducto(Producto producto, int cantidad)
        {
            if (PuedeAgregarProducto(producto, cantidad).Any()) throw new System.Exception(string.Join(",", _errores));

            if (!ExisteProducto(producto))
            {
                ProductoBodegas.Add(new ProductoBodega
                {
                    Producto = producto,
                    Cantidad = cantidad
                });
            }
            else
            {
                ProductoBodegas.FirstOrDefault(x => x.Producto == producto).Cantidad += cantidad;
            }
            return ProductoBodegas.FirstOrDefault(x => x.Producto == producto);
        }

        public ProductoBodega SacarProducto(Producto producto, int cantidad)
        {
            if (!ExisteProducto(producto)) return null;

            ProductoBodega productoBodega = ProductoBodegas.FirstOrDefault(x => x.Producto == producto);
            if (productoBodega.Cantidad >= cantidad)
            {
                productoBodega.Cantidad -= cantidad; //Private
                return new ProductoBodega {
                    Producto = producto,
                    Cantidad = cantidad
                };
            }
            return null;
        }

        public ProductoBodega TrasladarProducto(IBodega bodega, Producto producto, int cantidad)
        {
            var productoBodegaExtraido = SacarProducto(producto, cantidad);
            if (productoBodegaExtraido != null)
            {
                return bodega.AgregarProducto(producto, cantidad);
            }
            return null;
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