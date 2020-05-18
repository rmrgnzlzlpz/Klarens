using Application.Base;
using Domain.Entities;

namespace Application.Models
{
    public class PagoRequest : IRequest<Pago>
    {
        public string NumeroDocumento { get; set; }
        public double Valor { get; set; }
        public PagoEstado Estado { get; set; }
        public Pago ToEntity()
        {
            return new Pago
            {
                Valor = this.Valor,
                Estado = this.Estado
            };
        }
    }
}
