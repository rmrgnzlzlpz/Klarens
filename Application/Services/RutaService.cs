using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class RutaService : Service<Ruta>
    {
        public RutaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RutaRepository)
        {
        }

        public Response<Ruta> Add(RutaRequest request)
        {
            Ruta entity = request.ToEntity();
            
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new RutaResponse("Ruta no registrada");
            }
            return new RutaResponse("Ruta registrada", entity);
        }
    }
}