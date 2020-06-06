using Domain.Base;

namespace Domain.Entities
{
    public class Proveedor : Entity<int>
    {
        public Persona Persona { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }

        public Proveedor(Persona persona, Usuario usuario)
        {
            Persona = persona;
            Usuario = usuario;
        }

        public Proveedor() {}
    }
}