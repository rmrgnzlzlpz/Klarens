using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class VehiculoService : BaseService<Vehiculo>
    {
        public VehiculoService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.VehiculoRepository)
        {
        }

        public IResponse<Vehiculo> Add(VehiculoRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}