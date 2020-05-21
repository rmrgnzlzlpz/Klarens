using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Builders
{
    public class CompraBuilder
    {
        public List<CompraDetalle> Detalles { get; private set; }
        
        public CompraBuilder()
        {
            Detalles = new List<CompraDetalle>();
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
    }
}
