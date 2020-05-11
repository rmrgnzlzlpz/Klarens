using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Rol : Entity<int>
    {
        public List<Usuario> Usuarios { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public RolEstado Estado { get; set; }
    }

    public enum RolEstado
    {
        Inactivo = 0, Activo = 1,
    }
}