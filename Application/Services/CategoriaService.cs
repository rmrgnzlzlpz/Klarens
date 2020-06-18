using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class CategoriaService : Service<Categoria>
    {
        public CategoriaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CategoriaRepository)
        {
        }

        public CategoriaResponse Add(CategoriaRequest request)
        {
            Categoria entity = _repository.FindFirstOrDefault(x => x.Nombre == request.Nombre);

            if (entity != null)
            {
                return new CategoriaResponse($"La categoría {request.Nombre} ya existe");
            }

            entity = request.ToEntity();

            base.Add(entity);
            _unitOfWork.Commit();

            if (entity.Id == 0)
            {
                return new CategoriaResponse("Categoria no registrada");
            }
            return new CategoriaResponse("Categoria registrada", entity);
        }

        private bool ExisteCategoria(string nombre)
        {
            return _repository.FindFirstOrDefault(x => x.Nombre == nombre) != null;
        }

        public SubcategoriaResponse Add(SubcategoriaRequest request)
        {
            Categoria categoria = _repository.FindFirstOrDefault(x => x.Nombre == request.Categoria);
            if (categoria == null)
            {
                return new SubcategoriaResponse($"No existe la categoría {request.Categoria}");
            }

            var entity = categoria.AgregarSubcategoria(request.Nombre, request.Descripcion, request.Estado);

            _repository.Edit(categoria);

            if (_unitOfWork.Commit() < 1)
            {
                return new SubcategoriaResponse("Subcategoría no registrada");
            }

            return new SubcategoriaResponse("Subcategoría registrada", entity);
        }
    }
}