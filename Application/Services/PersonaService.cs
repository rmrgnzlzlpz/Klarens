using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResponse<Vendedor> ToVendedor(VendedorRequest request)
        {
            Persona persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == request.NumeroDocumento);
            if (persona == null)
            {
                return new Response<Vendedor>("No existe la persona con este número de documento.");
            }

            Vendedor vendedor = _unitOfWork.VendedorRepository.FindBy(x => x.Persona.Documento.Numero == request.NumeroDocumento).FirstOrDefault();
            if (vendedor != null)
            {
                return new Response<Vendedor>("Ya existe este vendedor.", vendedor);
            }

            vendedor = new Vendedor(persona, null);

            return new Response<Vendedor>(
                "Registro guardado con éxito",
                vendedor
            );
        }

        public IResponse<Persona> Get(PersonaRequest request)
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
            if (request.NumeroDocumento != null  && request.NumeroDocumento != string.Empty)
            {
                personas = personas.Where(x => x.Documento.Numero.Contains(request.NumeroDocumento));
            }
            if (request.Telefono != null && request.Telefono != string.Empty)
            {
                personas = personas.Where(x => x.Telefono.Contains(request.Telefono));
            }

            return new Response<Persona>("Registros consultados", personas.ToList());
        }
    }
}