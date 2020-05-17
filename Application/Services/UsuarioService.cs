using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class UsuarioService : BaseService<Usuario>
    {
        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UsuarioRepository)
        {
        }

        public IResponse<Usuario> Add(UsuarioRequest request)
        {
            Usuario usuario = _repository.FindFirstOrDefault(x => x.Username == request.Username);
            if (usuario == null)
            {
                return new Response<Usuario>(
                    mensaje: $"El usuario {request.Username} ya existe",
                    entidad: request.ToEntity()
                );
            }
            return base.Add(request.ToEntity());
        }
    }
}