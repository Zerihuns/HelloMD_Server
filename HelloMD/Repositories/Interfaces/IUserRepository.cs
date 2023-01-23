using HelloMD.Dtos;
using HelloMD.models;

namespace HelloMD.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> Suspend(UserDto user);
        Task<User> Confirm(string username, string pass);
    }
}
