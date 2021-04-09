using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using RegistarApi.Entities;
using RegistarApi.Model;

namespace RegistarApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);

    }
}
