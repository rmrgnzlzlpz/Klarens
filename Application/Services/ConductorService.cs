using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ConductorService : BaseService<Conductor>
    {
        public ConductorService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ConductorRepository)
        {
        }

        public IResponse<Conductor> Add(ConductorRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}