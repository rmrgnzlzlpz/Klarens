using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Application.Models
{
    public class VentaRequest : IRequest<Venta>
    {
        public string Username { get; set; }
        public string DocumentoVendedor { get; set; }
        public List<VentaDetalleRequest> Detalles { get; set; }
        public string NumeroFactura { get; set; }
        public double Abonado { get; set; }
        public double Impuesto { get; set; }
        public Venta ToEntity()
        {
            return new Venta(new List<VentaDetalle>())
            {
                Comprobante = new Comprobante { Numero = NumeroFactura, Tipo = ComprobanteTipo.Factura },
                Estado = VentaEstado.Activa,
                Impuesto = Impuesto,
                Pagado = Abonado
            };
        }
    }

    public class VentaDetalleRequest : IRequest<VentaDetalle>
    {
        public string CodigoProducto { get; set; }
        public string CodigoBodega { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        private Producto Producto { get; set; }

        public VentaDetalle ToEntity()
        {
            return new VentaDetalle
            {
                Cantidad = this.Cantidad,
                Precio = this.Precio,
                Descuento = this.Descuento,
            };
        }
    }
}
