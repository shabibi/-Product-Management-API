using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public interface IUserRepo
    {
        void AddUser(User user);
        User GetUSer(string email, string password);
    }
}