using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.AccountAPI.Models;
using StockMarket.AccountAPI.Services;

namespace StockMarket.AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountController : ControllerBase
    {
        UserService service = new UserService();

        [HttpGet]
        [Route("Login/{uname}/{passwd}")]
        public IActionResult Login(string uname, string passwd)
        {
            User u = service.Login(uname, passwd);
            if(u != null)
            {
                return Ok(u);
            }
            else
            {
                return NotFound("Invalid User");
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User item)
        {
            service.AddUser(item);
            return Ok();
        }
    }
}
