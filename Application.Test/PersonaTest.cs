using System.Linq;
using Application.Models;
using Application.Services;
using Domain.Contracts;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Test
{
    public class PersonaTests
    {
        PersonaService personaService;
        IUnitOfWork unitOfWork;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<KlarensContext>().UseInMemoryDatabase("Klarens").Options;
            KlarensContext context = new KlarensContext(options);
            unitOfWork = new UnitOfWork(context);

            personaService = new PersonaService(unitOfWork);
        }

        [Test]
        public void PersonaTest()
        {
            PersonaRequest request = new Models.PersonaRequest
            {
                NumeroDocumento = "1082460156",
                TipoDocumento = ComprobanteTipo.Cedula,
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Nombre = "Ramiro",
                Direccion = new Models.DireccionRequest
                {
                    Numero = "8-9#15",
                    Barrio = "Loma Fresca",
                    Ciudad = "San Sebastián",
                    Pais = "Colombia",
                    TipoDireccion = DireccionTipo.Calle,
                }
            };

            string response = personaService.Add(request).Mensaje;

            Assert.AreEqual($"La persona con {request.TipoDocumento} número {request.NumeroDocumento} se encuentra registrada", response);
        }

        [Test(Description = "Como administrador quiero registrar las personas que participarán en la empresa para tener un control de clientes")]
        public void PersonaRepetidaTest()
        {
            Persona persona = personaService.Add(new Models.PersonaRequest
            {
                NumeroDocumento = "1082460156",
                TipoDocumento = ComprobanteTipo.Cedula,
                Email = "rmrgnzlzlpz@gmail.com",
                Telefono = "3177471037",
                Nombre = "Ramiro",
                Direccion = new Models.DireccionRequest
                {
                    Numero = "8-9#15",
                    Barrio = "Loma Fresca",
                    Ciudad = "San Sebastián",
                    Pais = "Colombia",
                    TipoDireccion = DireccionTipo.Calle,
                }
            }).Entidades.FirstOrDefault();

            Assert.NotNull(persona);
        }
    }
}