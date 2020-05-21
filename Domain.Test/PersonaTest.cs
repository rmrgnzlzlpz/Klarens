using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using NUnit.Framework;

namespace Domain.Test
{
    public class PersonaTests
    {
        Rol admin;
        Persona persona;
        Comprobante comprobante;

        [SetUp]
        public void Setup()
        {
            admin = new Rol
            {
                Nombre = "Administrador",
                Descripcion = "Rol principal del sistema",
                Estado = RolEstado.Activo
            };
        }

        [Test(Description = "Como administrador quiero registrar las personas para tener un control de clientes.")]
        public void CrearPersona()
        {
            comprobante = new Comprobante { Numero = "1082480166", Tipo = ValueObjects.ComprobanteTipo.Cedula };

            persona = new Persona
            {
                Nombre = "Ramiro González",
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Documento = comprobante
            };

            Assert.NotNull(persona);

            var personaGuardada = new
            {
                persona.Nombre,
                persona.Email,
                persona.Telefono,
                persona.Documento
            };

            var personaEsperada = new 
            {
                Nombre = "Ramiro González",
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Documento = comprobante
            };

            Assert.AreEqual(personaEsperada, personaGuardada);
        }

        [Test(Description = "Las personas pueden convertirse en vendedores")]
        public void PersonaAVendedor()
        {
            comprobante = new Comprobante { Numero = "1082480166", Tipo = ValueObjects.ComprobanteTipo.Cedula };

            persona = new Persona
            {
                Nombre = "Ramiro González",
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Documento = comprobante
            };

            Vendedor vendedor = new Vendedor(persona, new Usuario(admin, "RmrGnzlz", "eewi9304orjklwe923i"));

            Assert.AreEqual(persona, vendedor.Persona);
        }

        [Test(Description = "Las personas pueden convertirse en Proveedores")]
        public void PersonaAProveedor()
        {
            comprobante = new Comprobante { Numero = "1082480166", Tipo = ValueObjects.ComprobanteTipo.Cedula };

            persona = new Persona
            {
                Nombre = "Ramiro González",
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Documento = comprobante
            };

            Proveedor proveedor = new Proveedor(persona, new Usuario(admin, "RmrGnzlz", "eewi9304orjklwe923i"));

            Assert.AreEqual(persona, proveedor.Persona);
        }

        [Test(Description = "Las personas pueden convertirse en conductores")]
        public void PersonaAConductor()
        {
            comprobante = new Comprobante { Numero = "1082480166", Tipo = ValueObjects.ComprobanteTipo.Cedula };

            persona = new Persona
            {
                Nombre = "Ramiro González",
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Documento = comprobante
            };

            Conductor conductor = new Conductor(persona);

            Assert.AreEqual(persona, conductor.Persona);
        }
    }
}