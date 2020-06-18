using System.Collections.Generic;
using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class VentaService : Service<Venta>
    {
        private ProductoService _productoService;
        public VentaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.VentaRepository)
        {
            _productoService = new ProductoService(_unitOfWork);
        }

        public VentaResponse Add(VentaRequest request)
        {
            Vendedor vendedor = _unitOfWork.VendedorRepository.FindFirstOrDefault(x => x.Persona.Documento.Numero == request.DocumentoVendedor);
            if (vendedor == null)
            {
                return new VentaResponse($"Vendedor con documento {request.DocumentoVendedor} no encontrado");
            }
            if (_repository.FindFirstOrDefault(x => x.Comprobante.Numero == request.NumeroFactura) != null)
            {
                return new VentaResponse($"La factura {request.NumeroFactura} ya está registrada");
            }

            List<VentaDetalle> Detalles = new List<VentaDetalle>();
            foreach (var item in request.Detalles)
            {
                ProductoBodega producto = _productoService.ProductoEnBodega(item.CodigoProducto, item.CodigoBodega);
                if (producto == null)
                {
                    return new VentaResponse($"Producto {item.CodigoProducto} no está disponible en bodega {item.CodigoBodega}");
                }
                if (_productoService.Disponible(item.CodigoProducto, item.CodigoBodega, item.Cantidad) == false)
                {
                    return new VentaResponse
                    (
                        mensaje: $"El producto {item.CodigoProducto} no está disponible para esa cantidad."
                    );
                }
                VentaDetalle detalle = item.ToEntity();
                detalle.ProductoBodega = producto;
                Detalles.Add(detalle);
            }

            Venta venta = request.ToEntity();
            venta.VentaDetalles = Detalles;

            vendedor.Ventas.Add(venta);

            _unitOfWork.Commit();

            return new VentaResponse
            (
                mensaje: "Venta registrada correctamente",
                entidad: venta
            );
        }
    }
}