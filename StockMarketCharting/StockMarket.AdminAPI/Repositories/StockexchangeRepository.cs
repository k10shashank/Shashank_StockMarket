using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public class StockexchangeRepository : IStockexchangeRepository
    {
        stockmarketdbContext db = new stockmarketdbContext();
        public void AddStockexchange(Stockexchange item)
        {
            db.Stockexchange.Add(item);
            db.SaveChanges();
        }

        public Stockexchange GetStockexchangeDetails(int id)
        {
            Stockexchange se = db.Stockexchange.SingleOrDefault(s => s.StockExchangeId == id);
            if(se != null)
            {
                return se;
            }
            else
            {
                return null;
            }
        }

        public List<Stockexchange> GetStockexchanges()
        {
            List<Stockexchange> se = new List<Stockexchange>();
            se = db.Stockexchange.ToList();
            if (se != null)
            {
                return se;
            }
            else
            {
                return null;
            }
        }
    }
}
