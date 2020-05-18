using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ProductoService : BaseService<Producto>
    {
        public ProductoService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ProductoRepository)
        {
        }

        public IResponse<Producto> Add(ProductoRequest request)
        {
            Producto producto = _repository.FindFirstOrDefault(x => x.Codigo == request.Codigo);
            if (producto != null)
            {
                return new Response<Producto>(
                    mensaje: $"El producto con código {request.Codigo} ya existe",
                    entidad: request.ToEntity()
                );
            }
            return base.Add(request.ToEntity());
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
    }
}