using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class RolService : BaseService<Rol>
    {
        public RolService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RolRepository)
        {
        }

        public IResponse<Rol> Add(RolRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}