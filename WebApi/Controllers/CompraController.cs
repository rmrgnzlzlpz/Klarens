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
    public class CompraController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly CompraService _service;
        public CompraController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new CompraService(_unitOfWork);
        }

        [HttpPost("nueva")]
        public ActionResult<CompraResponse> Nueva(CompraRequest request)
        {
            var response = _service.Add(request);
            return response;
        }

        [HttpGet("{pagina}/{cantidad}")]
        public ActionResult<CompraResponse> All(uint pagina, uint cantidad)
        {
            var response = _service.All(pagina, cantidad);
            return response;
        }
    }
}
