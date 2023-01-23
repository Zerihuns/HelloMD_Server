using HelloMD.Dtos;

namespace HelloMD.Services.Interface
{
    public interface IUserService
    {
        (UserDto, string) Authenticate(AuthenticateRequestDto model);
        Task<IEnumerable<UserDto>> GetAll();
        UserDto GetById(int id);
    }
}
