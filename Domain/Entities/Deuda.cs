using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Deuda : Entity<int>
    {
        public Persona Persona { get; set; }
        public double Valor { get; set; }
        public double Pagado { get; set; }
        public double Saldo { get => Valor - Pagado; }
        public DateTime Fecha { get; set; }
        public DeudaEstado Estado { get {
            if (Saldo == 0) return DeudaEstado.Pagada;
            if (Pagado == 0) return DeudaEstado.Vigente;
            return DeudaEstado.Parcial;
        }}
    }

    public enum DeudaEstado
    {
        Vigente = 0, Parcial = 1, Pagada = 2
    }
}