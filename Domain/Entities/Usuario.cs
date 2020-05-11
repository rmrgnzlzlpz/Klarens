using Domain.Base;

namespace Domain.Entities
{
    public class Usuario : Entity<int>
    {
        public Persona Persona { get; set; }
        public Rol Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UsuarioEstado Estado { get; set; }
    }

    public enum UsuarioEstado
    {
    }
}