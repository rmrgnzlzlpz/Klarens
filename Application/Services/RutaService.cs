using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class RutaService : BaseService<Ruta>
    {
        public RutaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RutaRepository)
        {
        }

        public IResponse<Ruta> Add(RutaRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}