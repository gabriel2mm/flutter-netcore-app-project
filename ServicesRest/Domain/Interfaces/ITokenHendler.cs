using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITokenHendler
    {
        bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters);
    }
}
