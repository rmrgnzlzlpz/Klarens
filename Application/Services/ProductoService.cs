using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ProductoService : Service<Producto>
    {
        public ProductoService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ProductoRepository)
        {
        }

        public Response<Producto> Add(ProductoRequest request)
        {
            Producto producto = _repository.FindFirstOrDefault(x => x.Codigo == request.Codigo);
            if (producto != null)
            {
                return new ProductoResponse(
                    mensaje: $"El producto con código {request.Codigo} ya existe",
                    entidad: request.ToEntity()
                );
            }
            Producto entity = request.ToEntity();
            
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new ProductoResponse("Producto no registrado");
            }
            return new ProductoResponse("Producto registrado", entity);
        }

        public bool Disponible(string codigoProducto, string codigoBodega, int cantidad)
        {
            var producto = ProductoEnBodega(codigoProducto, codigoBodega);
            if (producto == null) return false;
            if (producto.Cantidad < cantidad) return false;
            return true;
        }

        public ProductoBodega ProductoEnBodega(string codigoProducto, string codigoBodega)
        {
            return _unitOfWork.ProductoBodegaRepository.FindFirstOrDefault(x => x.Bodega.Codigo == codigoBodega && x.Producto.Codigo == codigoProducto);
        }

        public ProductoResponse GetBy(Expression<Func<Producto, bool>> expression = null, string include = "", uint page = 0, uint size = 10)
        {
            return new ProductoResponse("Productos consultados", base.Get(expression, include, page, size));
        }
    }
}