using System;
using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Builders;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class CompraService : Service<Compra>
    {
        private readonly ProductoService _productoService;
        public CompraService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CompraRepository)
        {
            _productoService = new ProductoService(_unitOfWork);
        }

        private bool ExisteFactura(string factura)
        {
            return _repository.FindBy(x => x.Comprobante.Numero == factura).Any();
        }
        public CompraResponse Add(CompraRequest request)
        {
            if (ExisteFactura(request.NumeroFactura))
            {
                return new CompraResponse($"La factura {request.NumeroFactura} ya está registrada");
            }

            CompraBuilder compraBuilder = new CompraBuilder(request.NumeroFactura);
            foreach (var item in request.Detalles)
            {
                Producto producto = _unitOfWork.ProductoRepository.FindFirstOrDefault(x => x.Codigo == item.CodigoProducto);
                compraBuilder = compraBuilder.AgregarDetalle(producto, item.Cantidad, item.PrecioCompra);
            }

            if (compraBuilder.IsOk().Any())
            {
                return new CompraResponse(string.Join(',', compraBuilder.IsOk()));
            }

            Compra compra = compraBuilder.Build(request.Pagado, request.Impuesto);

            if (_unitOfWork.Commit() > 0)
            {
                return new CompraResponse
                (
                    mensaje: "Compra registrada correctamente",
                    entidad: compra
                );
            }

            return new CompraResponse("No se pudo registrar la compra");
        }

        public CompraResponse All(uint pagina, uint cantidad)
        {
            return new CompraResponse("Ventas consultadas", base.Get(page: pagina, size: cantidad));
        }
    }
}