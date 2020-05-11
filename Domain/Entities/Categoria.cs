using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Categoria : Entity<int>
    {
        public List<Subcategoria> Subcategorias { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public CategoriaEstado Estado { get; set; }
    }

    public enum CategoriaEstado
    {
        Inactiva = 0, Activa = 1
    }
}