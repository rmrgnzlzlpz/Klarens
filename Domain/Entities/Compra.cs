using System;
using System.Collections.Generic;
using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Compra : Entity<int>
    {
        public List<CompraDetalle> CompraDetalles { get; set; }
        public Comprobante Comprobante { get; set; }
        public DateTime Fecha { get; set; }
        public double Impuesto { get; set; }
        public double Total { get {
            double total = 0;
            foreach (var detalle in CompraDetalles)
            {
                total += detalle.Total;
            }
            return total;
        }}
        public double Pagado { get; set; }
        public double Saldo { get => Total - Pagado; }
        public CompraEstado Estado { get {
            if (Pagado == 0) return CompraEstado.Activa;
            if (Saldo == 0) return CompraEstado.Pagada;
            return CompraEstado.Abonada;
        }}
        public Proveedor Proveedor { get; set; }
        public Usuario Usuario { get; set; }
        public bool Cancelada { get; set; } = false;

        public Compra(List<CompraDetalle> detalles)
        {
            CompraDetalles = detalles;
            Fecha = DateTime.UtcNow;
        }

        public Compra() { }
    }

    public enum CompraEstado
    {
        Activa = 0, Pagada = 1, Abonada = 2
    }
}