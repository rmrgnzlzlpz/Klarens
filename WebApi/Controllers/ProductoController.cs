using Application.Base;
using Application.Models;
using Application.Services;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ProductoService _service;
        public ProductoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new ProductoService(_unitOfWork);
        }

        [HttpGet("{pagina}/{cantidad}")]
        public ActionResult<IResponse<Producto>> GetAll(uint pagina = 0, uint cantidad = 10)
        {
            return Ok(_service.GetBy(page: pagina, size: cantidad));
        }

        [HttpGet("codigo")]
        public ActionResult<IResponse<Producto>> Get(string codigo)
        {
            var response = _service.GetBy(x => x.Codigo == codigo);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<IResponse<Producto>> Post(ProductoRequest request)
        {
            var response = _service.Add(request);
            return Ok(response);
        }
    }
}
