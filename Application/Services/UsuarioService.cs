using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UsuarioService : Service<Usuario>
    {
        readonly RolService _rolService;
        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UsuarioRepository)
        {
            _rolService = new RolService(_unitOfWork);
        }

        public UsuarioResponse Add(UsuarioRequest request)
        {
            Usuario entity = _repository.FindFirstOrDefault(x => x.Username == request.Username);

            if (entity != null)
            {
                return new UsuarioResponse($"El usuario {request.Username} ya existe", request.ToEntity());
            }

            entity = request.ToEntity();

            var rol = _rolService.GetRol(request.Rol);

            if (rol == null)
            {
                return new UsuarioResponse("Rol no existente");
            }

            entity.Rol = rol;
            entity.Estado = UsuarioEstado.Activo;
            entity.Password = new PasswordHasher<Usuario>().HashPassword(entity, request.Password);

            base.Add(entity);

            if (entity.Id == 0)
            {
                return new UsuarioResponse("No se pudo registrar el usuario");
            }
            entity.Rol.Usuarios = null;
            return new UsuarioResponse("Usuario registrado", entity);
        }

        public UsuarioResponse Update(UsuarioRequest request)
        {
            Usuario entity = _repository.FindFirstOrDefault(x => x.Username == request.Username);
            if (entity == null)
            {
                return new UsuarioResponse($"El usuario {request.Username} no existe");
            }

            Rol rol = _unitOfWork.RolRepository.FindFirstOrDefault(x => x.Nombre == request.Rol);

            if (rol == null) return new UsuarioResponse("No existe el rol");

            entity.Rol = rol;
            entity.Password = new PasswordHasher<Usuario>().HashPassword(entity, request.Password);

            base.Update(entity);
            return new UsuarioResponse("Usuario actualizado");
        }

        public UsuarioResponse GetBy(Expression<Func<Usuario, bool>> expression = null, uint page = 0, uint size = 10)
        {
            return new UsuarioResponse("Usuarios consultados", base.Get(expression: expression, page: page, size: size));
        }

        public UsuarioResponse Validar(UsuarioRequest request)
        {
            Usuario usuario = base.Get(x => x.Username == request.Username, include: "Rol", size: 1).FirstOrDefault();
            if (usuario == null)
            {
                return new UsuarioResponse($"No existe el usuario {request.Username}");
            }

            return ValidarPassword(usuario, request.Password) ? new UsuarioResponse("Usuario valido", usuario) : new UsuarioResponse("Usuario no válido");
        }
        private bool ValidarPassword(Usuario user, string password)
        {
            var verifier = new PasswordHasher<Usuario>().VerifyHashedPassword(user, user.Password, password);
            return verifier == PasswordVerificationResult.Success;
        }
    }
}