using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class PersonaService : Service<Persona>
    {
        public PersonaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.PersonaRepository)
        {
        }

        public Response<Persona> Add(PersonaRequest request)
        {
            Persona entity = request.ToEntity();

            if (_repository.FindBy(x => x.Documento.Numero == request.NumeroDocumento && x.Documento.Tipo == request.TipoDocumento).Any())
            {
                return new PersonaResponse($"La persona con {request.TipoDocumento} número {request.NumeroDocumento} se encuentra registrada");
            }
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new PersonaResponse("Persona no registrada");
            }
            return new PersonaResponse("Persona registrada", entity);
        }

        public Response<Persona> Get(PersonaRequest request)
        {
            IQueryable<Persona> personas = _repository.FindBy();
            if (request.Email != null && request.Email != string.Empty)
            {
                personas = personas.Where(x => x.Email.ToUpper().Contains(request.Email.ToUpper()));
            }
            if (request.Nombre != null && request.Nombre != string.Empty)
            {
                personas = personas.Where(x => x.Nombre.ToUpper().Contains(request.Nombre.ToUpper()));
            }
            if (request.NumeroDocumento != null && request.NumeroDocumento != string.Empty)
            {
                personas = personas.Where(x => x.Documento.Numero.Contains(request.NumeroDocumento));
            }
            if (request.Telefono != null && request.Telefono != string.Empty)
            {
                personas = personas.Where(x => x.Telefono.Contains(request.Telefono));
            }

            return new PersonaResponse("Registros consultados", personas.ToList());
        }
    }
}