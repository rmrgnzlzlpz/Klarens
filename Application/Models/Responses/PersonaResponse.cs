using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class PersonaResponse : Response<Persona>
    {
        public PersonaResponse(string mensaje) : base(mensaje)
        {
        }

        public PersonaResponse(string mensaje, List<Persona> entidades) : base(mensaje, entidades)
        {
        }

        public PersonaResponse(string mensaje, Persona entidad) : base(mensaje, entidad)
        {
        }
    }
}