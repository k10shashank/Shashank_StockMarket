using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    public class ComparisonService : IComparisonService
    {
        ComparisonRepository _repo = new ComparisonRepository();

        public List<Company> GetCompanies(string word)
        {
            return _repo.GetCompanies(word);
        }

        public Company GetCompany(string cmpname)
        {
            return _repo.GetCompany(cmpname);
        }
    }
}
