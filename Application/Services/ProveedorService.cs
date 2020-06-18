using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ProveedorService : Service<Proveedor>
    {
        public ProveedorService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ProveedorRepository)
        {
        }

        public ProveedorResponse Add(PersonaDerivadoRequest request)
        {
            Proveedor entity = new Proveedor();
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new ProveedorResponse("Proveedor no registrada");
            }
            return new ProveedorResponse("Proveedor registrada", entity);
        }

        public ProveedorResponse ConPersona(ConPersonaRequest request)
        {
            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == request.Persona.NumeroDocumento);
            
            if (persona == null)
            {
                return new ProveedorResponse("No existe la persona con este número de documento");
            }

            var proveedorRequest = new PersonaDerivadoRequest { NumeroDocumento = request.Persona.NumeroDocumento };
            return Add(proveedorRequest);
        }
    }
}