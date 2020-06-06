using Domain.Builders;
using Domain.Entities;
using Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Linq;

namespace Domain.Test
{
    public class DevolucionTests
    {
        Venta venta;
        Producto leche;
        Producto yogurt;

        [SetUp]
        public void Setup()
        {
            VentaBuilder ventaBuilder = new VentaBuilder();
            var bodega = new Bodega { Codigo = "001", Descripcion = "Principal", Tipo = BodegaTipo.Principal };

            leche = new Producto { Codigo = "LAC-001", Descripcion = "Leche de 1L", Nombre = "Leche Klarens 900ml", Precio = 2100, Estado = ProductoEstado.Activo };
            yogurt = new Producto { Codigo = "LAC-027", Descripcion = "Yogurt sencillo", Nombre = "Yogurt Klarens", Precio = 1200, Estado = ProductoEstado.Activo };

            var lecheBodega = bodega.AgregarProducto(leche, 10);
            var yogurtBodega = bodega.AgregarProducto(yogurt, 20);

            ventaBuilder = ventaBuilder
                .AgregarDetalle(lecheBodega, 2, 2100, 500)
                .AgregarDetalle(yogurtBodega, 5, 1200, 0)
                .AgregarComprobante(new Comprobante { Numero = "KL-V-0013" });

            venta = ventaBuilder.Build(100000, 10000);
        }

        [Test]
        public void DevolverProducto()
        {
            DevolucionBuilder devolucionBuilder = new DevolucionBuilder(venta);

            devolucionBuilder.AgregarDetalle(leche, 10).AgregarDetalle(yogurt, 2).AgregarDescripcion("Descripcion...");

            Devolucion devolucion = devolucionBuilder.Build();

            Assert.AreEqual(1, devolucion.DevolucionDetalles.Count);

            int cantidadEnVenta = venta.VentaDetalles.FirstOrDefault(x => x.ProductoBodega.Producto == yogurt).Cantidad;

            Assert.AreEqual(3, cantidadEnVenta);
        }

        [Test]
        public void DevolverVentaCancelada()
        {
            venta.Cancelar();
            DevolucionBuilder builder = new DevolucionBuilder(venta);
            builder.AgregarDetalle(leche, 1);

            Exception ex = Assert.Throws<Exception>(() => { builder.Build(); });

            Assert.IsTrue(ex.Message.Contains("No hay una venta válida para devolver"));
        }
    }
}