

using ani_server.Dto;
using ani_server.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace ani_server.Interfaces
{
    public interface IUser
    {
        Task<bool> RegisterUser(UserMaster user);
        bool CheckUserNameAvailability(string username);
        Task LoginUser(LoginRequestDto user);
    }
}