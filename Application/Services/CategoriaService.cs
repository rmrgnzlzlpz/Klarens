using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class CategoriaService : Service<Categoria>
    {
        public CategoriaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CategoriaRepository)
        {
        }

        public Response<Categoria> Add(CategoriaRequest request)
        {
            Categoria entity = request.ToEntity();
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new CategoriaResponse("Categoria no registrada");
            }
            return new CategoriaResponse("Categoria registrada", entity);
        }
    }
}