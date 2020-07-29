using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Services;

namespace StockMarket.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComparisonController : ControllerBase
    {
        ComparisonService service = new ComparisonService();

        [HttpGet]
        [Route("GetCompany/{cmpname}")]
        public IActionResult GetCompany(string cmpname)
        {
            Company cmp = service.GetCompany(cmpname);
            if (cmp != null)
            {
                return Ok(cmp);
            }
            else
            {
                return NotFound("Invalid Company ID");
            }
        }

        [HttpGet]
        [Route("GetCompanies/{word}")]
        public IActionResult GetCompanies(string word)
        {
            List<Company> cmplist = service.GetCompanies(word);
            if (cmplist != null)
            {
                return Ok(cmplist);
            }
            else
            {
                return NotFound("No Company Matched");
            }
        }
    }
}
