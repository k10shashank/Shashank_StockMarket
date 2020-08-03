using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{

    public class CompanyRepository : ICompanyRepository
    {
        private stockmarketdbContext db;
        public CompanyRepository(stockmarketdbContext _db)
        {
            db = _db;
        }
        //private stockmarketdbContext db = new stockmarketdbContext();
        public void AddCompany(Company item)
        {
            db.Company.Add(item);
            db.SaveChanges();
        }

        public void DeleteCompany(int id)
        {
            Company cmp = db.Company.Find(id);
            db.Company.Remove(cmp);
            db.SaveChanges();
        }

        public void EditCompany(Company item)
        {
            db.Company.Update(item);
            db.SaveChanges();
        }

        public List<Company> GetCompanies()
        {
            List<Company> cmp = new List<Company>();
            cmp = db.Company.ToList();
            if (cmp != null)
            {
                return cmp;
            }
            else
            {
                return null;
            }
        }

        public Company GetCompanyDetails(int id)
        {
            Company cmp = db.Company.SingleOrDefault(s => s.CompanyCode == id);
            if (cmp != null)
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
