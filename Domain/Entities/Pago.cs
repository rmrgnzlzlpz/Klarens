using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Pago : Entity<int>
    {
        public Deuda Deuda { get; set; }
        public DateTime Fecha { get; private set; }
        public double Valor { get; set; }
        public PagoEstado Estado { get; set; }
    }

    public enum PagoEstado
    {
        Activo = 0, Cancelado = 1
    }
}