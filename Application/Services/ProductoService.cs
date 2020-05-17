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
            Producto producto = _unitOfWork.ProductoRepository.FindFirstOrDefault(x => x.Codigo == request.Codigo && x.Estado == ProductoEstado.Activo);
            if (producto != null)
            {
                return new Response<Producto>(
                    mensaje: $"El producto con código {request.Codigo} ya existe",
                    entidad: request.ToEntity()
                );
            }
            return base.Add(request.ToEntity());
        }
    }
}