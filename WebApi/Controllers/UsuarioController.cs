using System;
using System.Linq;
using Application.Base;
using Application.Models;
using Application.Services;
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authentication;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly UsuarioService _service;
        readonly ITokenProvider _tokenProvider;
        public UsuarioController(IUnitOfWork unitOfWork, ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
            _service = new UsuarioService(_unitOfWork);
        }

        [HttpGet("{pagina}/{cantidad}")]
        public ActionResult<UsuarioResponse> GetAll(uint pagina = 0, uint cantidad = 10)
        {
            return Ok(_service.GetBy(page: pagina, size: cantidad));
        }

        [HttpGet]
        public ActionResult<UsuarioResponse> Get(string username)
        {
            var response = _service.GetBy(x => x.Username == username);
            return Ok(response);
        }

        [HttpGet("search")]
        public ActionResult<UsuarioResponse> Search(UsuarioRequest request)
        {
            var response = _service.GetBy(x => x.Estado == Domain.Entities.UsuarioEstado.Activo && x.Username.ToUpper().Contains(request.Username.ToUpper()) || x.Rol.Nombre.ToUpper().Contains(request.Rol.ToUpper()));
            return Ok(Response);
        }

        [HttpPost]
        public ActionResult<UsuarioResponse> Post(UsuarioRequest request)
        {
            var response = _service.Add(request);
            return Ok(response);
        }

        [HttpPost("auth")]
        public ActionResult<JsonWebToken> Auth(UsuarioRequest request)
        {
            var response = _service.Validar(request);

            if (response.Entidades == null)
            {
                return Unauthorized();
            }
            var user = response.Entidades.FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }
            
            return Ok(new JsonWebToken
            {
                Access_token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(5)),
                Expires_in = 5*60
            });
        }
    }
}
