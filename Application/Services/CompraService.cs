using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class CompraService : BaseService<Compra>
    {
        public CompraService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CompraRepository)
        {
        }

        public IResponse<Compra> Add(CompraRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}