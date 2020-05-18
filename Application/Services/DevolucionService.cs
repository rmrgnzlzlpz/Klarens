using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DevolucionService : BaseService<Devolucion>
    {
        public DevolucionService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DevolucionRepository)
        {
        }

        public IResponse<Devolucion> Add(DevolucionRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}