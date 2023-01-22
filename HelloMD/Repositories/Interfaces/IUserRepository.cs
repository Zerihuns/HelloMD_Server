using HelloMD.models;

namespace HelloMD.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
