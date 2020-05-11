using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class KlarensContext : DbContextBase
    {
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDetalle> CompraDetalles { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Deuda> Deudas { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }
        public DbSet<DevolucionDetalle> DevolucionDetalles { get; set; }
        public DbSet<Distribucion> Distribuciones { get; set; }
        public DbSet<DistribucionDetalle> DistribucionDetalles { get; set; }
        public DbSet<DistribucionVendedor> DistribucionVendedores { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoBodega> ProductosBodegas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }

        public KlarensContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<ProductoBodega>().HasKey(x => new { x.BodegaId, x.ProductoId });
            modelBuilder.Entity<DistribucionVendedor>().HasKey(x => new { x.VendedorId, x.DistribucionId });
        }
    }
}
