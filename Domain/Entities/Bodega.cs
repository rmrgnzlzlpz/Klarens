using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Bodega : Entity<int>
    {
        public List<ProductoBodega> ProductoBodegas { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public BodegaTipo Tipo { get; set; }
        public BodegaEstado Estado { get; set; }
    }

    public enum BodegaEstado
    {
        Inactiva = 0, Activa = 1
    }

    public enum BodegaTipo
    {
        Principal = 0, Secundaria = 1, Movil = 2
    }
}