

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
            string user = _dbcontext.UserMasters.FirstOrDefault(x => x.Username == username)?.ToString();
            return user == null;
        }

        public Task LoginUser(LoginRequestDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(UserMaster user)
        {
            bool isUserNameAvailable = CheckUserNameAvailability(user.Username);
            try
            {
                if(isUserNameAvailable)
                {
                    await _dbcontext.UserMasters.AddAsync(user);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
                else{
                    return false;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}