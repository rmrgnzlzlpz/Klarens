using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Builders
{
    public class CompraBuilder
    {
        public List<String> Errores { get; private set; }
        public List<CompraDetalle> Detalles { get; private set; }
        public Comprobante Comprobante { get; private set; }
        private int totalDetalles;

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
        public Compra Build(double abonado, double impuesto)
        {
            if (IsOk().Any()) throw new Exception(string.Join(',', Errores));
            return new Compra(Detalles)
            {
                Comprobante = Comprobante,
                Pagado = abonado,
                Impuesto = impuesto
            };
        }
        public List<string> IsOk()
        {
            Errores = new List<string>();
            if (Detalles == null)
            {
                Errores.Add("La compra debe tener mínimo un producto");
            }
            else
            {
                if (Detalles.Count < 1)
                {
                    Errores.Add("La compra debe tener mínimo un producto");
                }
                if (totalDetalles < Detalles.Count)
                {
                    Errores.Add($"No se agregaron todos los detalles ({Detalles.Count} de {totalDetalles})");
                }
            }
            return Errores;
        }
    }
}
