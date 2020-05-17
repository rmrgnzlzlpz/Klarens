using Application.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class UsuarioRequest : IRequest<Usuario>
    {
        public int PersonaId { get; set; }
        public int RolId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Usuario ToEntity()
        {
            return new Usuario
            {
                Username = Username, Password = Password
            };
        }
    }
}
