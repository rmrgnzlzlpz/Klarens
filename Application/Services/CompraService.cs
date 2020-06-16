using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class CompraService : Service<Compra>
    {
        public CompraService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CompraRepository)
        {
        }

        public Response<Compra> Add(CompraRequest request)
        {
            Compra entity = request.ToEntity();
            
            if (base.Add(entity) < 1)
            {
                return new CompraResponse("Compra no registrada");
            }
            return new CompraResponse("Compra registrada", entity);
        }
    }
}