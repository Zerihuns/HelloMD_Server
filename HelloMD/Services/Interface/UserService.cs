using HelloMD.Dtos;
using HelloMD.models;

namespace HelloMD.Services.Interface
{
    public interface IUserService
    {
        (UserDto, string) Authenticate(AuthenticateRequestDto model);
        Task<ICollection<User>> GetAll();
        Task<User> GetById(int id);
    }
}
