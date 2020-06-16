using System.Collections.Generic;
using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class VendedorService : Service<Vendedor>
    {
        public VendedorService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.VendedorRepository)
        {
        }

        public VendedorResponse Add(VendedorRequest request)
        {
            Vendedor vendedor = _repository.FindFirstOrDefault(x => x.Persona.Documento.Numero == request.NumeroDocumento);
            if (vendedor != null)
            {
                return new VendedorResponse
                (
                    $"El vendedor identificado con número {request.NumeroDocumento} ya existe"
                );
            }

            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == request.NumeroDocumento);

            vendedor = new Vendedor(persona, null);
            return new VendedorResponse("Vendedor creado exitosamente", vendedor);
        }

        public VendedorResponse FromPersona(FromPersonaRequest request)
        {
            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == request.Persona.NumeroDocumento);
            if (persona == null)
            {
                return new VendedorResponse("No existe la persona con este número de documento");
            }

            var vendedorRequest = new VendedorRequest { NumeroDocumento = request.Persona.NumeroDocumento };
            return Add(vendedorRequest);
        }

        public Response<Vendedor> ObtenerPorCedula(string documento)
        {
            return new VendedorResponse
            (
                mensaje: $"Vendedor {documento}",
                entidad: _repository.FindFirstOrDefault(x => x.Persona.Documento.Numero == documento)
            );
        }
    }
}