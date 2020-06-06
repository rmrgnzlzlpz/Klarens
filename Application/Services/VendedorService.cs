using System.Collections.Generic;
using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class VendedorService : BaseService<Vendedor>
    {
        public VendedorService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.VendedorRepository)
        {
        }

        public IResponse<Vendedor> Add(VendedorRequest request)
        {
            Vendedor vendedor = _repository.FindFirstOrDefault(x => x.Persona.Documento.Numero == request.NumeroDocumento);
            if (vendedor != null)
            {
                return new Response<Vendedor>
                (
                    mensaje: $"El vendedor identificado con número {request.NumeroDocumento} ya existe"
                );
            }

            vendedor = new Vendedor
            (
                _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == request.NumeroDocumento), null
            );

            return new Response<Vendedor>
            (
                mensaje: "Vendedor creado exitosamente",
                entidad: vendedor
            );
        }

        public IResponse<Vendedor> ObtenerPorCedula(string documento)
        {
            return new Response<Vendedor>
            (
                mensaje: $"Vendedor {documento}",
                entidad: _repository.FindFirstOrDefault(x => x.Persona.Documento.Numero == documento)
            );
        }
    }
}