using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Builders
{
    public class CompraBuilder
    {
        public List<String> Errores { get; private set; }
        public List<CompraDetalle> Detalles { get; private set; }
        public Comprobante Comprobante { get; private set; }

        public CompraBuilder(string numeroFactura)
        {
            Detalles = new List<CompraDetalle>();
            Comprobante = new Comprobante { Numero = numeroFactura, Tipo = ComprobanteTipo.Factura };
        }

        public CompraBuilder AgregarDetalle(Producto producto, int cantidad, double precio)
        {
            Detalles.Add(new CompraDetalle
            {
                Producto = producto,
                Cantidad = cantidad,
                Precio = precio
            });
            return this;
        }
        public Compra Build(Comprobante comprobante, double abonado, double impuesto)
        {
            return new Compra(Detalles)
            {
                Comprobante = comprobante,
                Pagado = abonado,
                Impuesto = impuesto
            };
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
