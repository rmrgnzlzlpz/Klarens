using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Builders
{
    public class VentaBuilder
    {
        public List<VentaDetalle> Detalles { get; private set; }
        public Comprobante Comprobante { get; private set; }
        public double Abonado { get; private set; }
        public List<string> Errores { get; private set; }
        
        public VentaBuilder()
        {
            Detalles = new List<VentaDetalle>();
        }

        public VentaBuilder AgregarDetalle(ProductoBodega producto, int cantidad, double precio, double descuento)
        {
            Detalles.Add(new VentaDetalle
            {
                ProductoBodega = producto,
                Cantidad = cantidad,
                Precio = precio,
                Descuento = descuento
            });
            return this;
        }

        public VentaBuilder AgregarComprobante(Comprobante comprobante)
        {
            Comprobante = comprobante ?? throw new Exception("El comprobante no puede estar vacío");
            return this;
        }

        public Venta Build(double abonado, double impuesto)
        {
            if (IsOk().Any()) throw new Exception(string.Join(',', Errores));

            return new Venta(Detalles)
            {
                Comprobante = this.Comprobante,
                Pagado = abonado,
                Impuesto = impuesto,
            };
        }

        public List<string> IsOk()
        {
            Errores = new List<string>();
            if (Detalles == null)
            {
                Errores.Add("La venta debe tener mínimo un producto.");
            } else
            {
                double total = 0;
                Detalles.ForEach(x => total += x.Total);
                if (Abonado > total) Errores.Add("El abono no puede ser mayor al total de la factura.");
            }
            if (Detalles.Count < 1)
            {
                Errores.Add("La venta debe tener mínimo un producto");
            }
            if (Comprobante == null) Errores.Add("El comprobante no debe estar vacío.");
            return Errores;
        }
    }
}
