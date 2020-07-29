using StockMarket.AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AccountAPI.Repositories
{
    interface IUserRepository
    {
        // Declare the functions of the Model (User)
        //Token Login(string uname, string passwd);
        User Login(string uname, string passwd);
        void AddUser(User item);
    }
}
