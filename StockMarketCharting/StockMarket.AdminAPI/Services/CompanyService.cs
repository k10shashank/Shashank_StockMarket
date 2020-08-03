using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _repo;
        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }
        //CompanyRepository _repo = new CompanyRepository();
        public void AddCompany(Company item)
        {
            _repo.AddCompany(item);
        }

        public void DeleteCompany(int id)
        {
            _repo.DeleteCompany(id);
        }

        public void EditCompany(Company item)
        {
            _repo.EditCompany(item);
        }

        public List<Company> GetCompanies()
        {
            return _repo.GetCompanies();
        }

        public Company GetCompanyDetails(int id)
        {
            return _repo.GetCompanyDetails(id);
        }
    }
}
