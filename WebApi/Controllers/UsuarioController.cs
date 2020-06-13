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
    public class UsuarioController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly UsuarioService _service;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new UsuarioService(_unitOfWork);
        }

        [HttpGet("{pagina}/{cantidad}")]
        public ActionResult<IResponse<Usuario>> GetAll(uint pagina = 0, uint cantidad = 10)
        {
            return Ok(_service.Get(page: pagina, size: cantidad));
        }

        [HttpGet]
        public ActionResult<IResponse<Usuario>> Get(string username)
        {
            var response = _service.Get(x => x.Username == username);
            return Ok(response);
        }

        [HttpGet("search")]
        public ActionResult<IResponse<Usuario>> Search(UsuarioRequest request)
        {
            var response = _service.Get(x => x.Estado == UsuarioEstado.Activo);
            return Ok(Response);
        }

        [HttpPost]
        public ActionResult<IResponse<Usuario>> Post(UsuarioRequest request)
        {
            var response = _service.Add(request);
            return Ok(response);
        }
    }
}
