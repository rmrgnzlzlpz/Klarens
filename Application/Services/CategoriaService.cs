using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class CategoriaService : BaseService<Categoria>
    {
        public CategoriaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CategoriaRepository)
        {
        }

        public IResponse<Categoria> Add(CategoriaRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}