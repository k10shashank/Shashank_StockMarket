using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Repositories
{
    public class SignupRepository : ISignupRepository
    {
        private stockmarketdbContext db = new stockmarketdbContext();
        public void AddUserAccount(User item)
        {
            db.User.Add(item);
            db.SaveChanges();
        }

        public void EditUserAccount(User item)
        {
            db.User.Update(item);
            db.SaveChanges();
        }
    }
}
