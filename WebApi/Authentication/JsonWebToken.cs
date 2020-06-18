using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;

namespace WebApi.Authentication
{
    public class JsonWebToken
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; } = "bearer";
        public int Expires_in { get; set; }
        public string Refresh_token { get; set; }
    }
}