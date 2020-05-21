using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Vehiculo : Entity<int>, IBodega
    {
        public Bodega Bodega { get; set; }
        public Comprobante Comprobante { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        public ProductoBodega AgregarProducto(Producto producto, int cantidad)
        {
            return Bodega.AgregarProducto(producto, cantidad);
        }

        public bool ExisteProducto(Producto producto)
        {
            return Bodega.ExisteProducto(producto);
        }

        public ProductoBodega TrasladarProducto(IBodega bodega, Producto producto, int cantidad)
        {
            return Bodega.TrasladarProducto(bodega, producto, cantidad);
        }
    }
}