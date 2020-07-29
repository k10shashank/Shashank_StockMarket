using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Services;

namespace StockMarket.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockexchangeController : ControllerBase
    {
        // --------------
        // Stock Exchange
        // --------------
        StockexchangeService service = new StockexchangeService();

        [HttpPost]
        [Route("AddStockexchange")]
        public IActionResult AddStockexchange(Stockexchange item)
        {
            service.AddStockexchange(item);
            return Ok();
        }

        [HttpGet]
        [Route("GetStockexchangeDetails/{id}")]
        public IActionResult GetStockexchangeDetails(int id)
        {
            Stockexchange se = service.GetStockexchangeDetails(id);
            if(se != null){
                return Ok(se);
            }
            else
            {
                return NotFound("Invalid Stock Exchange");
            }
        }

        [HttpGet]
        [Route("GetStockexchanges")]
        public IActionResult GetStockexchanges()
        {
            List<Stockexchange> se = service.GetStockexchanges();
            if(se != null)
            {
                return Ok(se);
            }
            else
            {
                return NotFound("No Stock Exchange");
            }
        }
    }
}
