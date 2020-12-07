using SimpleWebShop.App.Algorithms;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly AppDBContent _appDBContent;

        public UsersRepository(AppDBContent appDbContent)
        {
            _appDBContent = appDbContent;
        }

        public IEnumerable<User> GetAllUsers => _appDBContent.User;

        public void CreateUser(RegisterModel model)
        {

            var hashPassowrd = HashingPassword.GetHashPassword(model.password);

            _appDBContent.User.Add(new User
            {
                email = model.email,
                password = hashPassowrd,
                role = 0,
                name = model.name
            });
            _appDBContent.SaveChanges();
        }
    }
}
