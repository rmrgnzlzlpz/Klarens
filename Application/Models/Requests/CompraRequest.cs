using System.Collections.Generic;
using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Models
{
    public class CompraRequest : IRequest<Compra>
    {
        public List<CompraDetalleRequest> Detalles { get; set; }
        public string DocumentoProveedor { get; set; }
        public string NumeroComprobante { get; set; }
        public ComprobanteTipo TipoComprobante { get; set; }
        public double Pagado { get; set; }
        public double Impuesto { get; set; }

        public Compra ToEntity()
        {
            return new Compra
            {
                Comprobante = new Comprobante { Tipo = TipoComprobante, Numero = NumeroComprobante },
                Pagado = this.Pagado,
                Impuesto = this.Impuesto,
            };
        }
    }

    public class CompraDetalleRequest : IRequest<CompraDetalle>
    {
        public string CodigoProducto { get; set; }
        public string CodigoBodega { get; set; }
        public int Cantidad { get; set; }
        public double PrecioCompra { get; set; }

        public CompraDetalle ToEntity()
        {
            return new CompraDetalle
            {
                Cantidad = this.Cantidad,
                Precio = this.PrecioCompra
            };
        }
    }
}
