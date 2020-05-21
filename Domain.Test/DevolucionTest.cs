using Domain.Builders;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using NUnit.Framework;

namespace Domain.Test
{
    public class DevolucionTests
    {
        Venta venta;

        [SetUp]
        public void Setup()
        {
            VentaBuilder ventaBuilder = new VentaBuilder();

            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 2, 10000, 1200);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 4, 10500, 1200);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 1, 35000, 1500);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 5, 10000, 100);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 1, 10000, 0);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 1, 10000, 0);

            venta = ventaBuilder.Build(100000, 10000);
        }

        [Test]
        public void DevolverProducto()
        {

        }
    }
}