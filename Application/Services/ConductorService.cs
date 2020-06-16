using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ConductorService : Service<Conductor>
    {
        public ConductorService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ConductorRepository)
        {
        }

        public Response<Conductor> Add(ConductorRequest request)
        {
            Conductor entity = request.ToEntity();
            
            if (base.Add(entity) < 1)
            {
                return new ConductorResponse("Conductor no registrado");
            }
            return new ConductorResponse("Conductor registrado", entity);
        }
    }
}