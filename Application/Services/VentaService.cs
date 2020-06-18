using System;
using System.Collections.Generic;
using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Builders;
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

        private bool ExisteFactura(string factura)
        {
            return _repository.FindBy(x => x.Comprobante.Numero == factura).Any();
        }

        public VentaResponse Add(VentaRequest request)
        {
            Vendedor vendedor = _unitOfWork.VendedorRepository.FindFirstOrDefault(x => x.Persona.Documento.Numero == request.DocumentoVendedor);
            if (vendedor == null)
            {
                return new VentaResponse($"Vendedor con documento {request.DocumentoVendedor} no encontrado");
            }
            if (ExisteFactura(request.NumeroFactura))
            {
                return new VentaResponse($"La factura {request.NumeroFactura} ya está registrada");
            }

            VentaBuilder ventaBuilder = new VentaBuilder(request.NumeroFactura);
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
                ventaBuilder = ventaBuilder.AgregarDetalle(producto, item.Cantidad, item.Precio, item.Descuento);
            }

            if (ventaBuilder.IsOk().Any())
            {
                return new VentaResponse(string.Join(',', ventaBuilder.IsOk()));
            }

            Venta venta = ventaBuilder.Build(request.Abonado, request.Impuesto);

            vendedor.Vender(venta);

            _unitOfWork.VendedorRepository.Edit(vendedor);

            if (_unitOfWork.Commit() > 0)
            {
                return new VentaResponse
                (
                    mensaje: "Venta registrada correctamente",
                    entidad: venta
                );
            }

            return new VentaResponse("No se pudo registrar la venta");
        }

        public VentaResponse All(uint pagina, uint cantidad)
        {
            return new VentaResponse("Ventas consultadas", base.Get(page: pagina, size: cantidad));
        }
    }
}