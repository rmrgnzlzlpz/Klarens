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
            
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new RolResponse("Rol no registrado");
            }
            return new RolResponse("Rol registrado", entity);
        }

        public Rol GetRol(string name)
        {
            return _repository.FindFirstOrDefault(x => x.Nombre.ToUpper() == name.ToUpper());
        }
    }
}