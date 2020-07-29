using StockMarket.AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace StockMarket.AccountAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        stockmarketdbContext db = new stockmarketdbContext();

        public void AddUser(User item)
        {
            db.User.Add(item);
            db.SaveChanges();
        }

        public User Login(string uname, string passwd)
        {
            User user = db.User.SingleOrDefault(u => u.Username == uname && u.Password == passwd);
            if(user != null)
            {
                //return new Token() { token = "check token" };
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
