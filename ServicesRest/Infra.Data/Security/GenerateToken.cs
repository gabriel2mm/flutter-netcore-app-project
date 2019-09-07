using Domain.Entity;
using Domain.Interfaces;
using Infra.Data.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Security
{
    class GenerateToken : IGenerateToken
    {
        public string CreateToken(Usuario user)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(1);

            string secret_key = ConfigurationManager.AppSettings["secret_key"];
            string url = ConfigurationManager.AppSettings["JWT_URI"];

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Login),
            });

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secret_key));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(issuer: url, audience: url, subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);

            return tokenHandler.WriteToken(token);
        }

        public Usuario GetCredentials(string login, string password)
        {
            using (UsuarioRepository repository = new UsuarioRepository())
            {
                Usuario user = repository.Get((u => u.Login == login && u.Password == password)).FirstOrDefault();
                if (user != null)
                {
                    user.Password = String.Empty;
                    return user;
                }
                return null;
            }
        }
    }
}