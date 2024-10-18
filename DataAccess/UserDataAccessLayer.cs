

using ani_server.DataBaseContext;
using ani_server.Dto;
using ani_server.Interfaces;
using ani_server.Models;
using Microsoft.EntityFrameworkCore;

namespace ani_server.DataAccess
{
    public class UserDataAccessLayer : IUser
    {
        readonly AniSaveDbContext _dbcontext;
        public UserDataAccessLayer(IDbContextFactory<AniSaveDbContext> dbContext)
        {
            _dbcontext = dbContext.CreateDbContext();
        }
        public bool CheckUserNameAvailability(string username)
        {
            throw new NotImplementedException();
        }

        public Task LoginUser(LoginRequestDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(UserMaster user)
        {
            throw new NotImplementedException();
        }
    }
}