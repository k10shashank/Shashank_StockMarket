using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Services
{
    public class StockexchangeService : IStockexchangeService
    {
        StockexchangeRepository _repo = new StockexchangeRepository();

        public void AddStockexchange(Stockexchange item)
        {
            _repo.AddStockexchange(item);
        }

        public Stockexchange GetStockexchangeDetails(int id)
        {
            return _repo.GetStockexchangeDetails(id);
        }

        public List<Stockexchange> GetStockexchanges()
        {
            return _repo.GetStockexchanges();
        }
    }
}
