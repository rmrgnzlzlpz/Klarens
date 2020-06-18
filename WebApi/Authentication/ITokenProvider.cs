using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;

namespace WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(Usuario user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}