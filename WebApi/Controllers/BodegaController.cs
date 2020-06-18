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
    public class BodegaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly BodegaService _service;
        public BodegaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new BodegaService(_unitOfWork);
        }

        [HttpGet("{pagina}/{cantidad}")]
        public ActionResult<BodegaResponse> GetAll(uint pagina = 0, uint cantidad = 10)
        {
            return Ok(_service.GetBy(page: pagina, size: cantidad));
        }

        [HttpGet("{codigo}")]
        public ActionResult<BodegaResponse> Get(string codigo)
        {
            var response = _service.GetBy(x => x.Codigo == codigo);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<BodegaResponse> Post(BodegaRequest request)
        {
            var response = _service.Add(request);
            return Ok(response);
        }
    }
}
