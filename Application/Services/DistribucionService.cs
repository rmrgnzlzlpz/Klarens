using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DistribucionService : BaseService<Distribucion>
    {
        public DistribucionService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DistribucionRepository)
        {
        }

        public IResponse<Distribucion> Add(DistribucionRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}