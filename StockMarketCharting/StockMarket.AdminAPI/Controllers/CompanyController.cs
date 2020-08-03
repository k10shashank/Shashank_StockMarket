using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Services;

namespace StockMarket.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CompanyController : ControllerBase
    {
        private CompanyService service;
        public CompanyController(CompanyService _service)
        {
            service = _service;
        }
        //CompanyService service = new CompanyService();

        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddCompany(Company item)
        {
            service.AddCompany(item);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            service.DeleteCompany(id);
            return Ok();
        }

        [HttpPut]
        [Route("EditCompany")]
        public IActionResult EditCompany(Company item)
        {
            service.EditCompany(item);
            return Ok();
        }

        [HttpGet]
        [Route("GetCompanies")]
        public IActionResult GetCompanies()
        {
            List<Company> cmp = new List<Company>();
            cmp = service.GetCompanies();
            if (cmp != null)
            {
                return Ok(cmp);
            }
            else
            {
                return NotFound("No Company");
            }
        }

        [HttpGet]
        [Route("GetCompanyDetails/{id}")]
        public IActionResult GetCompanyDetails(int id)
        {
            Company cmp = service.GetCompanyDetails(id);
            if (cmp != null)
            {
                return Ok(cmp);
            }
            else
            {
                return NotFound("Invalid Company ID");
            }
        }
    }
}
