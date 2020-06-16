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

        public ProveedorResponse Add(ProveedorRequest request)
        {
            Proveedor entity = request.ToEntity();
            
            if (base.Add(entity) < 1)
            {
                return new ProveedorResponse("Proveedor no registrada");
            }
            return new ProveedorResponse("Proveedor registrada", entity);
        }

        public ProveedorResponse FromPersona(FromPersonaRequest request)
        {
            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == request.Persona.NumeroDocumento);
            if (persona == null)
            {
                return new ProveedorResponse("No existe la persona con este número de documento");
            }

            var proveedorRequest = new ProveedorRequest { NumeroDocumento = request.Persona.NumeroDocumento };
            return Add(proveedorRequest);
        }
    }
}