using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenerateToken
    {
        User GetCredentials(string login, string password);
        String CreateToken(User user);
    }
}
