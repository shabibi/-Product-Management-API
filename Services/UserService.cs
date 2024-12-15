using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userrepo;

        public UserService(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }


        public void AddUser(User user)
        {

            _userrepo.AddUser(user);
        }

        public User GetUser(string email, string password)
        {
            return _userrepo.GetUSer(email, password);

        }
    }
}
