using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    interface ISignupService
    {
        void AddUserAccount(User item);
        void EditUserAccount(User item);
    }
}
