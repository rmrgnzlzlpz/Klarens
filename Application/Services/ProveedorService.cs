using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ProveedorService : BaseService<Proveedor>
    {
        public ProveedorService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ProveedorRepository)
        {
        }

        public IResponse<Proveedor> Add(ProveedorRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}