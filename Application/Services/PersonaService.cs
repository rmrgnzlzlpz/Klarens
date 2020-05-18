using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class PersonaService : BaseService<Persona>
    {
        public PersonaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.PersonaRepository)
        {
        }

        public IResponse<Persona> Add(PersonaRequest request)
        {
            return base.Add(request.ToEntity());
        }
    }
}