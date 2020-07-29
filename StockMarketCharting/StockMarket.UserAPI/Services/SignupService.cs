using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    public class SignupService : ISignupService
    {
        SignupRepository _repo = new SignupRepository();
        public void AddUserAccount(User item)
        {
            _repo.AddUserAccount(item);
        }

        public void EditUserAccount(User item)
        {
            _repo.EditUserAccount(item);
        }
    }
}
