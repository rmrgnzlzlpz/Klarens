using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Persona : Entity<int>
    {
        public string Nombre { get; set; }
        public Comprobante Documento { get; set; }
        public Direccion Direccion { get; set; }
        [Phone] public string Telefono { get; set; }
        [EmailAddress] public string Email { get; set; }
        public List<Deuda> Deudas { get; set; }
        public double Deuda { get {
            if (Deudas == null) return 0;
            double total = 0;
            foreach (var deuda in Deudas)
            {
                total += deuda.Valor;
            }
            return total;
        }}

        /*
        public Pago Abonar(double valor)
        {
            if (valor > 0 && valor < Deuda)
            {
                if (Deudas == null) return null;
                foreach (var item in Deudas.Where(x => x.Estado != DeudaEstado.Pagada))
                {
                    
                }
                Pago pago = new Pago { Valor = valor, Estado = PagoEstado.Activo };
            }
        }
        */
    }
}