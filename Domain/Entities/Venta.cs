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
        public double Pagado { get; private set; }
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
    }

    public enum VentaEstado
    {

    }
}