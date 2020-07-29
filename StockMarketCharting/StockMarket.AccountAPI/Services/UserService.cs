using StockMarket.AccountAPI.Models;
using StockMarket.AccountAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AccountAPI.Services
{
    public class UserService : IUserService
    {
        UserRepository _repo = new UserRepository();

        public void AddUser(User item)
        {
            _repo.AddUser(item);
        }

        public User Login(string uname, string passwd)
        {
            return _repo.Login(uname, passwd);
        }
    }
}
