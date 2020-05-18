using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class BodegaRequest : IRequest<Bodega>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public BodegaTipo Tipo { get; set; }
        public BodegaEstado Estado { get; set; }

        public Bodega ToEntity()
        {
            return new Bodega
            {
                Codigo = this.Codigo,
                Descripcion = this.Descripcion,
                Tipo = this.Tipo,
                Estado = this.Estado
            };
        }
    }
}
