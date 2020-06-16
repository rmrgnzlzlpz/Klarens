using Application.Base;
using Application.Models;
using Domain.Base;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class BodegaService : Service<Bodega>
    {
        public BodegaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.BodegaRepository)
        {
        }

        public Response<Bodega> Add(BodegaRequest request)
        {
            Bodega entity = request.ToEntity();
            
            if (base.Add(entity) < 1)
            {
                return new BodegaResponse("Bodega no registrada");
            }
            return new BodegaResponse("Bodega registrada", entity);
        }
    }
}