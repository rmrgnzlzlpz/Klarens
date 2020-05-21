using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Venta : Entity<int>
    {
        [Required] public List<VentaDetalle> VentaDetalles { get; set; }
        public Vendedor Vendedor { get; set; }
        public Comprobante Comprobante { get; set; }
        public double Pagado { get; set; }
        public double Total { get {
            double total = 0;
            foreach(var detalle in VentaDetalles)
            {
                total += detalle.Total;
            }
            return total;
        }}
        public double Saldo { get => Total - Pagado; }
        public VentaEstado Estado { get; set; }
        public DateTime Fecha { get; set; }
        public double Impuesto { get; set; }
        public Usuario Usuario { get; set; }
        public List<Devolucion> Devoluciones { get; set; }

        public Venta(List<VentaDetalle> detalles)
        {
            if (detalles == null) throw new ArgumentException("Los detalles no pueden estar vacíos");
            if (detalles.Count < 1) throw new ArgumentException("Los detalles no pueden estar vacíos");
            VentaDetalles = detalles;
            Fecha = DateTime.UtcNow;
        }

        public bool Cancelar()
        {
            Estado = VentaEstado.Cancelada;
            return Estado == VentaEstado.Cancelada;
        }
    }

    public enum VentaEstado
    {
        Activa = 0, Cancelada = 1
    }
}