using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(string email, string password);
    }
}