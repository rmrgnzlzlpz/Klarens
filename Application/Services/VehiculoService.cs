using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class VehiculoService : Service<Vehiculo>
    {
        public VehiculoService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.VehiculoRepository)
        {
        }

        public Response<Vehiculo> Add(VehiculoRequest request)
        {
            Vehiculo entity = request.ToEntity();
            if (base.Add(entity) < 1)
            {
                return new VehiculoResponse("No se pudo registrar el vehículo");
            }
            return new VehiculoResponse("Vehículo registrado", entity);
        }
    }
}