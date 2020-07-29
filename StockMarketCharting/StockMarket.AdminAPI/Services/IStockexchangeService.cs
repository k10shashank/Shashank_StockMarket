using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    interface IStockexchangeService
    {
        List<Stockexchange> GetStockexchanges();
        Stockexchange GetStockexchangeDetails(int id);
        void AddStockexchange(Stockexchange item);
    }
}
