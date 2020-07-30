using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Services;

namespace StockMarket.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SignupController : ControllerBase
    {
        SignupService service = new SignupService();

        [HttpPost]
        [Route("AddUserAccount")]
        public IActionResult AddUserAccount(User item)
        {
            service.AddUserAccount(item);
            return Ok();
        }

        [HttpPut]
        [Route("EditUserAccount")]
        public IActionResult EditUserAccount(User item)
        {
            service.EditUserAccount(item);
            return Ok();
        }
    }
}
