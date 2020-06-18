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
    public class VentaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly VentaService _service;
        public VentaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new VentaService(_unitOfWork);
        }

        [HttpPost("nueva")]
        public ActionResult<BaseResponse> Nueva(VentaRequest request)
        {
            BaseResponse response = _service.Add(request);
            return response;
        }
    }
}
