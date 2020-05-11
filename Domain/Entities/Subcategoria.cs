using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Subcategoria : Entity<int>
    {
        public Categoria Categoria { get; set; }
        public List<Producto> Productos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public CategoriaEstado Estado { get; set; }
    }
}