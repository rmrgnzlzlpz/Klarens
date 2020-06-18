using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class DevolucionRequest : Request<Devolucion>
    {
        public string NumeroFactura { get; set; }
        public List<DevolucionDetalleRequest> Detalles { get; set; }
        public override Devolucion ToEntity()
        {
            return new Devolucion();
        }
    }

    public class DevolucionDetalleRequest : Request<DevolucionDetalle>
    {
        public string CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public override DevolucionDetalle ToEntity()
        {
            return new DevolucionDetalle
            {
                Cantidad = Cantidad
            };
        }
    }
}
