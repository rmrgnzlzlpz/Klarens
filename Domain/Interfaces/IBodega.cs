using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBodega
    {
        ProductoBodega TrasladarProducto(IBodega bodega, Producto producto, int cantidad);
        ProductoBodega AgregarProducto(Producto producto, int cantidad);
        bool ExisteProducto(Producto producto);
    }
}