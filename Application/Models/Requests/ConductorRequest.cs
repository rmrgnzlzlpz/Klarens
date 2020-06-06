using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class ConductorRequest : IRequest<Conductor>
    {
        public ConductorEstado Estado { get; set; }

        public Conductor ToEntity()
        {
            return new Conductor
            {
                Estado = this.Estado
            };
        }
    }

    public class ConductorPersonaRequest : IRequest<Conductor>
    {
        public PersonaRequest Persona { get; set; }
        public ConductorEstado Estado { get; set; }
        public Conductor ToEntity()
        {
            return new Conductor(this.Persona.ToEntity())
            {
                Estado = this.Estado
            };
        }
    }
}
