using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class BodegaService : BaseService<Bodega>
    {
        public BodegaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.BodegaRepository)
        {
        }

        public IResponse<Bodega> Add(BodegaRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}