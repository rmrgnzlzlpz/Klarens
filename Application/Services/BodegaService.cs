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

        public BodegaResponse Add(BodegaRequest request)
        {
            Bodega entity = _repository.FindFirstOrDefault(x => x.Codigo == request.Codigo);
            if (entity != null)
            {
                return new BodegaResponse($"Ya existe una bodega con el código {request.Codigo}");
            }

            entity = new Bodega
            {
                Codigo = request.Codigo,
                Descripcion = request.Descripcion,
                Direccion = request.Direccion.ToEntity(),
                Estado = request.Estado,
                Tipo = request.Tipo
            };

            base.Add(entity);

            _unitOfWork.Commit();
            
            if (entity.Id == 0)
            {
                return new BodegaResponse("Bodega no registrada");
            }
            return new BodegaResponse("Bodega registrada", entity);
        }

        public BodegaResponse GetBy(Expression<Func<Bodega, bool>> expression = null, uint page = 0, uint size = 10)
        {
            return new BodegaResponse("Bodegas consultados", base.Get(expression: expression, page: page, size: size, include: "Direccion"));
        }
    }
}