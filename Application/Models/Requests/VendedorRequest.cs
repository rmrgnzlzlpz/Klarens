using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class VendedorRequest : IRequest<Vendedor>
    {
        public string NumeroDocumento { get; set; }
        public Vendedor ToEntity()
        {
            return new Vendedor();
        }
    }

    public class VendedorPersonaRequest : IRequest<Vendedor>
    {
        public PersonaRequest Persona { get; set; }
        public Vendedor ToEntity()
        {
            return new Vendedor
            (
                this.Persona.ToEntity(),
                null
            );
        }
    }
}
