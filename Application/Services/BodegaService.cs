using System;
using System.Linq.Expressions;
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
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new BodegaResponse("Bodega no registrada");
            }
            return new BodegaResponse("Bodega registrada", entity);
        }

        public BodegaResponse GetBy(Expression<Func<Bodega, bool>> expression = null, uint page = 0, uint size = 10)
        {
            return new BodegaResponse("Bodegas consultados", base.Get(expression: expression, page: page, size: size));
        }
    }
}