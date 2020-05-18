using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class CategoriaRequest : IRequest<Categoria>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public CategoriaEstado Estado { get; set; }
        public Categoria ToEntity()
        {
            return new Categoria
            {
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                Estado = this.Estado,
            };
        }
    }
}
