using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chat_ddsv.Models;
using Microsoft.IdentityModel.Tokens;

namespace Chat_ddsv.Services
{
    public static class TokenService
    {
        public static string CriarToken(Usuario usuario)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Settings.secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                //RefreshToken
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email), //User.Identity.Name
                })
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}