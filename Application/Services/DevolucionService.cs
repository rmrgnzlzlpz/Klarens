using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Builders;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DevolucionService : Service<Devolucion>
    {
        public DevolucionService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DevolucionRepository)
        {
        }

        public DevolucionResponse Add(DevolucionRequest request)
        {
            Venta venta = _unitOfWork.VentaRepository.FindBy(x => x.Comprobante.Numero == request.NumeroFactura, includeProperties: "VentaDetalles").FirstOrDefault();

            if (venta == null)
            {
                return new DevolucionResponse($"Factura {request.NumeroFactura} no encontrada");
            }

            DevolucionBuilder builder = new DevolucionBuilder(venta);

            foreach (var item in request.Detalles)
            {
                Producto producto = _unitOfWork.ProductoRepository.FindFirstOrDefault(x => x.Codigo == item.CodigoProducto);
                builder = builder.AgregarDetalle(producto, item.Cantidad);
            }

            if (builder.IsOk().Any())
            {
                return new DevolucionResponse(string.Join(',', builder.IsOk()));
            }

            Devolucion entity = builder.Build();
            venta.Devolver(entity);

            _unitOfWork.VentaRepository.Edit(venta);
            if (_unitOfWork.Commit() <= 0)
            {
                return new DevolucionResponse("No se pudo registrar la devolución");
            }
            return new DevolucionResponse("Devolucion registrada", entity);
        }

        public DevolucionResponse All(uint page, uint size)
        {
            return new DevolucionResponse("Devoluciones consultadas", base.Get(page: page, size: size));
        }
    }
}