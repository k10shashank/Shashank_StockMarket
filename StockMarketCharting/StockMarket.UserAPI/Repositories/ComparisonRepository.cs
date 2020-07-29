using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Repositories
{
    public class ComparisonRepository : IComparisonRepository
    {
        private stockmarketdbContext db = new stockmarketdbContext();

        public List<Company> GetCompanies(string word)
        {
            List<Company> cmplist = new List<Company>();
            var query = from cmp in db.Company
                      where cmp.CompanyName.Contains(word)
                      select cmp;
            cmplist = query.ToList<Company>();
            return cmplist;
        }

        public Company GetCompany(string cmpname)
        {
            Company cmp = db.Company.SingleOrDefault(s => s.CompanyName == cmpname);
            if(cmp != null)
            {
                return cmp;
            }
            else
            {
                return null;
            }
        }
    }
}
