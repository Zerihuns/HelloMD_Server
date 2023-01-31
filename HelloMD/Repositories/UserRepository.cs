using HelloMD.Dtos;
using HelloMD.models;
using HelloMD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NameAPIProxyService.Data;

namespace HelloMD.Repositories
{
    public class UserRepository :  GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory<HelloMDDbContext> context) : base(context){}

        public async Task<User> Confirm(string username, string pass)
        {
            var user = await Where(x => x.Username == username && x.Password == pass).FirstOrDefaultAsync();
           
            return user;
        }

        public Task<bool> Suspend(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
