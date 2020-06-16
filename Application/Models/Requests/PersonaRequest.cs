using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;
namespace Application.Models
{
    public class PersonaRequest : Request<Persona>
    {
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public ComprobanteTipo TipoDocumento { get; set; }
        public DireccionRequest Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public override Persona ToEntity()
        {
            return new Persona
            {
                Nombre = this.Nombre,
                Documento = new Comprobante { Numero = NumeroDocumento, Tipo = TipoDocumento },
                Direccion = this.Direccion.ToEntity(),
                Telefono = this.Telefono,
                Email = this.Email
            };
        }
    }

    public class FromPersonaRequest : Request<Domain.Base.BaseEntity>
    {
        public PersonaRequest Persona { get; set; }
        public UsuarioRequest Usuario { get; set; }
        public override Domain.Base.BaseEntity ToEntity()
        {
            return null;
        }
    }
}
