using Domain.Base;

namespace Domain.Entities
{
    public class Conductor : Entity<int>
    {
        public Persona Persona { get; private set; }
        public ConductorEstado Estado { get; set; }

        public Conductor(Persona persona)
        {
            Persona = persona;
        }
    }

    public enum ConductorEstado
    {
        Inactivo = 0, Activo = 1
    }
}