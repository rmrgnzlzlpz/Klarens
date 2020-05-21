using System.Collections.Generic;
using System.Linq;
using Domain.Base;

namespace Domain.Entities
{
    public class Categoria : Entity<int>
    {
        public List<Subcategoria> Subcategorias { get; set; } = new List<Subcategoria>();
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public CategoriaEstado Estado { get; set; }

        public List<string> PuedeAgregarSubcategoria(string nombre, string descripcion, CategoriaEstado estado)
        {
            List<string> errores = new List<string>();
            if (string.IsNullOrEmpty(nombre)) errores.Add("Debe especificar un nombre");
            return errores;
        }

        public Subcategoria AgregarSubcategoria(string nombre, string descripcion, CategoriaEstado estado)
        {
            var errores = PuedeAgregarSubcategoria(nombre, descripcion, estado);
            if (errores.Any()) throw new System.InvalidOperationException(string.Join(',', errores));
            var subcategoria = new Subcategoria
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Estado = estado
            };
            Subcategorias.Add(subcategoria);
            return subcategoria;
        }
    }

    public enum CategoriaEstado
    {
        Inactiva = 0, Activa = 1
    }
}