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
    public class DevolucionController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly DevolucionService _service;
        public DevolucionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new DevolucionService(_unitOfWork);
        }

        [HttpPost("nueva")]
        public ActionResult<DevolucionResponse> Post(DevolucionRequest request)
        {
            DevolucionResponse response = _service.Add(request);

            return Ok(response);
        }

        [HttpGet("{pagina}/{cantidad}")]
        public ActionResult<DevolucionResponse> All(uint pagina, uint cantidad)
        {
            var response = _service.All(pagina, cantidad);
            return response;
        }
    }
}
