using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class RolService : Service<Rol>
    {
        public RolService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RolRepository)
        {
        }

        public Response<Rol> Add(RolRequest request)
        {
            Rol entity = request.ToEntity();
            
            if (base.Add(entity) < 1)
            {
                return new RolResponse("Rol no registrado");
            }
            return new RolResponse("Rol registrado", entity);
        }
    }
}