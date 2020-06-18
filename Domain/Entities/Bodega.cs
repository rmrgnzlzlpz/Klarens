using System.Collections.Generic;
using System.Linq;
using Domain.Base;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Bodega : Entity<int>, IBodega
    {
        public IList<ProductoBodega> ProductoBodegas { get; private set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Direccion Direccion { get; set; }
        public BodegaTipo Tipo { get; set; }
        public BodegaEstado Estado { get; set; }

        public Bodega()
        {
            ProductoBodegas = new List<ProductoBodega>();
        }

        public bool ExisteProducto(Producto producto)
        {
            if (ProductoBodegas == null) return false;
            return ProductoBodegas.FirstOrDefault(x => x.Producto.Codigo == producto.Codigo) != null;
        }

        public ProductoBodega AgregarProducto(Producto producto, int cantidad)
        {
            var errores = PuedeAgregarProducto(producto, cantidad);
            if (errores.Any()) throw new System.InvalidOperationException(string.Join(",", errores));

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
            if (productoBodega.RestarCantidad(cantidad) > 0)
            {
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

        public List<string> PuedeAgregarProducto(Producto producto, int cantidad)
        {
            List<string> errores = new List<string>();
            if (cantidad < 1) errores.Add("La cantidad del producto debe ser mayor a 0.");
            if (producto == null) errores.Add("Producto no válido.");
            return errores;
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