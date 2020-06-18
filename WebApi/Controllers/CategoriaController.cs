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
    public class CategoriaController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly CategoriaService _service;
        public CategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _service = new CategoriaService(_unitOfWork);
        }

        [HttpPost("nueva")]
        public ActionResult<CategoriaResponse> Post(CategoriaRequest request)
        {
            CategoriaResponse response = _service.Add(request);
            return Ok(response);
        }

        [HttpPost("nueva/subcategoria")]
        public ActionResult<SubcategoriaResponse> PostSubcategoria(SubcategoriaRequest request)
        {
            SubcategoriaResponse response = _service.Add(request);

            return Ok(response);
        }
    }
}
