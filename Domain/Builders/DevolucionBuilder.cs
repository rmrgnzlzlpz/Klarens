using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Builders
{
    public class DevolucionBuilder
    {
        public List<string> Errores { get; private set; }
        public Venta Venta { get; private set; }
        public string Descripcion { get; private set; }
        public List<DevolucionDetalle> Detalles { get; private set; }
        public int TotalDetalles { get; private set; }

        public DevolucionBuilder(Venta venta)
        {
            if (venta.Estado != VentaEstado.Cancelada) Venta = venta;
            Detalles = new List<DevolucionDetalle>();
        }

        public DevolucionBuilder AgregarDetalle(Producto producto, int cantidad)
        {
            TotalDetalles++;
            if (Venta == null) return this;
            if (Venta.VentaDetalles == null) return this;
            var productoBodega = Venta.VentaDetalles.FirstOrDefault(x => x.ProductoBodega.Producto == producto);
            if (productoBodega == null) return this;

            if (productoBodega.Cantidad < cantidad) return this;

            productoBodega.Cantidad -= cantidad;
            Detalles.Add(new DevolucionDetalle
            {
                Producto = producto,
                Cantidad = cantidad
            });

            return this;
        }

        public DevolucionBuilder AgregarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
            return this;
        }

        public Devolucion Build()
        {
            if (IsOk().Any()) throw new Exception(string.Join(',', Errores));
            return new Devolucion(Venta, Detalles) { Descripcion = Descripcion };
        }

        public List<string> IsOk()
        {
            Errores = new List<string>();
            if (Detalles == null)
            {
                Errores.Add("La devolución debe tener mínimo un producto");
            }
            if (Detalles.Count < 1)
            {
                Errores.Add("La devolución debe tener mínimo un producto");
            }
            if (Venta.VentaDetalles == null)
            {
                Errores.Add("La venta debe tener mínimo un detalle");
            }
            if (Venta == null)
            {
                Errores.Add("No hay una venta válida para devolver");
            }
            if (TotalDetalles < Detalles.Count)
            {
                Errores.Add($"No se agregaron todos los detalles ({Detalles.Count} de {TotalDetalles})");
            }
            return Errores;
        }
    }
}
