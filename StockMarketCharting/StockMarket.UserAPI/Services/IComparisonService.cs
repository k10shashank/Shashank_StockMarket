using StockMarket.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.UserAPI.Services
{
    interface IComparisonService
    {
        Company GetCompany(string cmpname);
        List<Company> GetCompanies(string word);
    }
}
