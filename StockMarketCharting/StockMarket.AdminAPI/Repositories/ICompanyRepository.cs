using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    interface ICompanyRepository
    {
        List<Company> GetCompanies();
        Company GetCompanyDetails(int id);
        void AddCompany(Company item);
        void EditCompany(Company item);
        void DeleteCompany(int id);

    }
}
