using Domain.Base;

namespace Domain.Entities
{
    public class Conductor : Entity<int>
    {
        public Persona Persona { get; set; }
        public ConductorEstado Estado { get; set; }
    }

    public enum ConductorEstado
    {
        Inactivo = 0, Activo = 1
    }
}