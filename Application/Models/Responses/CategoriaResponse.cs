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
}