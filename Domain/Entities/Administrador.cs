using Domain.Base;

namespace Domain.Entities
{
    public class Administrador : Entity<int>
    {
        public Persona Persona { get; set; }
        public Usuario Usuario { get; set; }
    }
}