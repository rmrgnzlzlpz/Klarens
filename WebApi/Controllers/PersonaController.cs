using Application.Base;
using Application.Models;
using Application.Services;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly PersonaService _service;
        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new PersonaService(_unitOfWork);
        }

        [HttpPost]
        public ActionResult<IResponse<Persona>> Post(PersonaRequest request)
        {
            var response = _service.Add(request);
            return Ok(response);
        }

        [HttpPost("vendedor")]
        public ActionResult<IResponse<Vendedor>> ToVendedor(VendedorRequest request)
        {
            IResponse<Vendedor> response = _service.ToVendedor(request);
            if (response.Entidades == null) return  BadRequest(response);
            return Ok(response);
        }

        [HttpGet("{documento}")]
        public ActionResult<IResponse<Persona>> Get(string documento)
        {
            var response = _service.Get(x => x.Documento.Numero == documento);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IResponse<Persona>> GetAll(PersonaRequest request)
        {
            var response = _service.Get(request);
            return Ok(response);
        }
    }
}
