using Application.Services;
using Domain.Contracts;
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
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}