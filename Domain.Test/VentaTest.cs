using Domain.Builders;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Test
{
    public class VentaTests
    {
        Venta venta;
        Vendedor vendedor;
        [SetUp]
        public void Setup()
        {
            Rol rol = new Rol { Nombre = "Administrador" };
            Persona persona = new Persona
            {
                Nombre = "Ramiro González",
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Documento = new Comprobante { Numero = "1082480166", Tipo = ValueObjects.ComprobanteTipo.Cedula }
            };

            vendedor = new Vendedor(persona, new Usuario(rol, "rmrgnzlz", "238218391283"));
        }

        [Test(Description = "Creamos una venta usando el patrón builder, asignando detalles y al final construyéndola.")]
        public void ConstruirVenta()
        {
            VentaBuilder ventaBuilder = new VentaBuilder();

            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 2, 10000, 1200);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 4, 10500, 1200);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 1, 35000, 1500);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 5, 10000, 100);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 1, 10000, 0);
            ventaBuilder = ventaBuilder.AgregarDetalle(new ProductoBodega(), 1, 10000, 0);
            ventaBuilder.AgregarComprobante(new Comprobante { Numero = "12345", Tipo = ComprobanteTipo.Factura });
            venta = ventaBuilder.Build(100000, 10000);

            Assert.NotNull(venta.VentaDetalles);
            Assert.AreEqual(6, venta.VentaDetalles.Count);
        }

        [Test(Description = "Intentamos crear una venta sin detalles")]
        public void ConstruirVentaVacia()
        {
            VentaBuilder builder = new VentaBuilder();
            builder.AgregarComprobante(new Comprobante { Numero = "1111", Tipo = ComprobanteTipo.Factura });
            Exception ex = Assert.Throws<Exception>(() => { builder.Build(0, 0); });

            Assert.IsTrue(ex.Message.Contains("La venta debe tener mínimo un producto"));
        }

        [Test(Description = "Intentamos crear una venta sin un comprobante")]
        public void ConstruirVentaSinComprobante()
        {
            VentaBuilder builder = new VentaBuilder();
            builder.AgregarDetalle(new ProductoBodega(), 10, 1000, 100);
            Exception ex = Assert.Throws<Exception>(() => { builder.Build(0, 0); });

            Assert.IsTrue(ex.Message.Contains("El comprobante no debe estar vacío"));
        }

        // Validar suma de detalles == total
    }
}