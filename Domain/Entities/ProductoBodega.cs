using Domain.Base;

namespace Domain.Entities
{
    public class ProductoBodega : BaseEntity
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int BodegaId { get; set; }
        public Bodega Bodega { get; set; }
        public int Cantidad { get; set; }

        public int RestarCantidad(int cantidadRestada)
        {
            if (cantidadRestada > Cantidad) return 0;
            Cantidad -= cantidadRestada;
            return cantidadRestada;
        }
    }
}