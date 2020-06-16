using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Application.Models
{
    public class VentaRequest : IRequest<Venta>
    {
        public string DocumentoVendedor { get; set; }
        public List<VentaDetalleRequest> Detalles { get; set; }
        public string NumeroComprobante { get; set; }
        public ComprobanteTipo TipoComprobante { get; set; }
        public double Abonado { get; set; }
        public VentaEstado Estado { get; set; }
        public double Impuesto { get; set; }
        public int Username { get; set; }
        public Venta ToEntity()
        {
            return new Venta(null)
            {
                Comprobante = new Comprobante { Numero = NumeroComprobante, Tipo = TipoComprobante },
                Pagado = this.Abonado,
                Estado = this.Estado,
                Impuesto = this.Impuesto
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
