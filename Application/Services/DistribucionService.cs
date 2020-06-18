using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DistribucionService : Service<Distribucion>
    {
        public DistribucionService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DistribucionRepository)
        {
        }

        public Response<Distribucion> Add(DistribucionRequest request)
        {
            Distribucion entity = request.ToEntity();
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new DistribucionResponse("Distribucion no registrada");
            }
            return new DistribucionResponse("Distribucion registrada", entity);
        }
    }
}