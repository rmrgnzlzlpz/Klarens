using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class UsuarioRequest : Request<Usuario>
    {
        public string Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public override Usuario ToEntity()
        {
            return new Usuario(Username,  Password);
        }
    }
}
