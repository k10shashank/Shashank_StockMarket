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
    public class StockpriceController : ControllerBase
    {
        StockpriceService service = new StockpriceService();
        
        [HttpGet]
        [Route("CheckMissingData/{cmpcode}/{*date:datetime}")]
        public IActionResult CheckMissingData(int cmpcode, DateTime date)
        {
            bool flag = service.CheckMissingData(cmpcode, date);
            if (flag)
            {
                return Ok("Data Available");
            }
            else
            {
                return Ok("Data Not Available");
            }
        }

        [HttpGet]
        [Route("GetStockprices/{cmpcode}")]
        public IActionResult GetStockprices(int cmpcode)
        {
            List<Stockprice> stockprices = new List<Stockprice>();
            stockprices = service.GetStockprices(cmpcode);
            if (stockprices != null)
            {
                return Ok(stockprices);
            }
            else
            {
                return NotFound("No Stocks");
            }
        }
    }
}
