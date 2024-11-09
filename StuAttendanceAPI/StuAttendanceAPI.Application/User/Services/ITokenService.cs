using System;
using System.Linq;

namespace Application.User.Services
{
    public interface ITokenService
    {
        string Generate(UserDtoForClaims user);
    }
}



