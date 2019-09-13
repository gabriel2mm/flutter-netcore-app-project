using Microsoft.IdentityModel.Tokens;
using System;

namespace Domain.Interfaces
{
    public interface ITokenHendler
    {
        bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters);
    }
}
