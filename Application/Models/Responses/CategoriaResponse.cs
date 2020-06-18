using System.Collections.Generic;
using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class CategoriaResponse : Response<Categoria>
    {
        public CategoriaResponse(string mensaje) : base(mensaje)
        {
        }

        public CategoriaResponse(string mensaje, List<Categoria> entidades) : base(mensaje, entidades)
        {
        }

        public CategoriaResponse(string mensaje, Categoria entidad) : base(mensaje, entidad)
        {
        }
    }

    public class SubcategoriaResponse : Response<Subcategoria>
    {
        public SubcategoriaResponse(string mensaje) : base(mensaje)
        {
        }

        public SubcategoriaResponse(string mensaje, List<Subcategoria> entidades) : base(mensaje, entidades)
        {
        }

        public SubcategoriaResponse(string mensaje, Subcategoria entidad) : base(mensaje, entidad)
        {
        }
    }
}