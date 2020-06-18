using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DevolucionService : Service<Devolucion>
    {
        public DevolucionService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DevolucionRepository)
        {
        }

        public Response<Devolucion> Add(DevolucionRequest request)
        {
            Devolucion entity = request.ToEntity();
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new DevolucionResponse("Devolucion no registrada");
            }
            return new DevolucionResponse("Devolucion registrada", entity);
        }
    }
}