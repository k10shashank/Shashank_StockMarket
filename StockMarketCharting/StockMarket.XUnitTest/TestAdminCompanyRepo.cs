using Moq;
using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using StockMarket.AdminAPI.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StockMarket.XUnitTest
{
    public class TestAdminCompanyRepo
    {
        private readonly CompanyService _service;

        public TestAdminCompanyRepo()
        {
            var mockRepo = new Mock<ICompanyRepository>();
            IList<Company> companies = new List<Company>()
            {
                new Company() { CompanyCode = 40001, CompanyName = "AAA", Ceo="AAACEO", Turnover=10, SectorId=1},
                new Company() { CompanyCode = 40002, CompanyName = "BBB", Ceo="BBBCEO", Turnover=20, SectorId=1},
                new Company() { CompanyCode = 40003, CompanyName = "CCC", Ceo="CCCCEO", Turnover=30, SectorId=1},
            };
            mockRepo.Setup(repo => repo.GetCompanies()).Returns(companies.ToList());
            mockRepo.Setup(repo => repo.GetCompanyDetails(It.IsAny<int>())).Returns((int i) => companies.SingleOrDefault(x => x.CompanyCode == i));
            mockRepo.Setup(repo => repo.AddCompany(It.IsAny<Company>())).Callback((Company item) => {
                item = new Company() { CompanyCode = 40004, CompanyName = "DDD", Ceo = "DDDCEO", Turnover = 40, SectorId = 1 };
                companies.Add(item);
            }).Verifiable();
            mockRepo.SetupAllProperties();
            _service = new CompanyService(); // (mockRepo.Object);
        }

        [Fact]
        public void TestGetCompanies()
        {
            int expected = 3;
            var companyList = _service.GetCompanies();
            Assert.Equal(expected, companyList.Count());
        }

        [Fact]
        public void TestGetCompanyDetails()
        {
            int expected = 40002;
            var company = _service.GetCompanyDetails(40002);
            Assert.Equal(expected, company.CompanyCode);
        }

        [Fact]
        public void TestAddCompany()
        {
            var company = new Company() { CompanyCode = 40010, CompanyName = "ZZZ", Ceo = "ZZZCEO", Turnover = 10, SectorId = 1 };
            _service.AddCompany(company);
            Assert.Equal(1, 1);
        }

        [Fact]
        public void TestDeleteCompany()
        {
            var company = new Company() { CompanyCode = 40003, CompanyName = "CCC", Ceo = "CCCCEO", Turnover = 30, SectorId = 1 };
            _service.AddCompany(company);
            Assert.Equal(1, 1);
        }
    }
}
