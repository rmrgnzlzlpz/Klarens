using Domain.Base;

namespace Domain.ValueObjects
{
    public class Comprobante : Entity<int>
    {
        public ComprobanteTipo Tipo { get; set; }
        public string Numero { get; set; }
    }

    public enum ComprobanteTipo
    {
        Cedula = 0, NIT = 1, RUT = 2, Placa = 3, Factura = 4
    }
}