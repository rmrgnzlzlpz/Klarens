using Domain.Entities;
using Domain.Interfaces;
using NUnit.Framework;

namespace Domain.Test
{
    public class BodegaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearBodega()
        {
            Bodega bodega = new Bodega
            {
                Codigo = "B-1",
                Descripcion = string.Empty,
                Tipo = BodegaTipo.Principal,
                Estado = BodegaEstado.Activa
            };

            Assert.NotNull(bodega);

            var bodega1 = new
            {
                Codigo = bodega.Codigo,
                Descripcion = bodega.Descripcion,
                Tipo = bodega.Tipo,
                Estado = bodega.Estado
            };

            var bodega2 = new 
            {
                Codigo = "B-1",
                Descripcion = string.Empty,
                Tipo = BodegaTipo.Principal,
                Estado = BodegaEstado.Activa
            };

            Assert.AreEqual(bodega2, bodega1);
        }
    }
}