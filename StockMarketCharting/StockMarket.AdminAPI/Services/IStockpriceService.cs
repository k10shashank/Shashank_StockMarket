using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    interface IStockpriceService
    {
        bool CheckMissingData(int cmpcode, DateTime date);
        List<Stockprice> GetStockprices(int cmpcode);
    }
}
