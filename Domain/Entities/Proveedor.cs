using Domain.Base;

namespace Domain.Entities
{
    public class Proveedor : Entity<int>
    {
        public Persona Persona { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
    }
}