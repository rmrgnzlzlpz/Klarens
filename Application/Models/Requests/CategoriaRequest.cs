using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class CategoriaRequest : Request<Categoria>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public CategoriaEstado Estado { get; set; }
        public override Categoria ToEntity()
        {
            return new Categoria
            {
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                Estado = this.Estado,
            };
        }
    }

    public class SubcategoriaRequest : Request<Subcategoria>
    {
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public CategoriaEstado Estado { get; set; }
        public override Subcategoria ToEntity()
        {
            return new Subcategoria
            {
                Nombre = this.Nombre,
                Descripcion = this.Descripcion,
                Estado = this.Estado,
            };
        }
    }
}
