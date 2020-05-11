using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}