using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Models
{
    public class VehiculoRequest : IRequest<Vehiculo>
    {
        public BodegaRequest Bodega { get; set; }
        public string NumeroPlaca { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public Vehiculo ToEntity()
        {
            Bodega.Tipo = BodegaTipo.Movil;
            return new Vehiculo
            {
                Bodega = this.Bodega.ToEntity(),
                Comprobante = new Comprobante { Numero = NumeroPlaca, Tipo = ComprobanteTipo.Placa },
                Marca = this.Marca,
                Color = this.Color
            };
        }
    }
}
