using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class UsuarioService : Service<Usuario>
    {
        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UsuarioRepository)
        {
        }

        public Response<Usuario> Add(UsuarioRequest request)
        {
            Usuario entity = _repository.FindFirstOrDefault(x => x.Username == request.Username);
            if (entity == null)
            {
                return new UsuarioResponse($"El usuario {request.Username} ya existe",request.ToEntity());
            }
            if (base.Add(entity) < 1)
            {
                return new UsuarioResponse("No se pudo registrar el vehículo");
            }
            return new UsuarioResponse("Vehículo registrado", entity);
        }
    }
}