using Application.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class ProductoRequest : IRequest<Producto>
    {
        public int SubcategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double PrecioSugerido { get; set; }
        public string Descripcion { get; set; }
        public ProductoEstado Estado { get; set; }
        public Producto ToEntity()
        {
            var producto = new Producto
            {
                Codigo = this.Codigo,
                Nombre = this.Nombre, 
                Precio = this.PrecioSugerido, 
                Descripcion = this.Descripcion, 
                Estado = this.Estado
            };
            return producto;
        }
    }
}
