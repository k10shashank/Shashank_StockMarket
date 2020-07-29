using StockMarket.AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminAPI.Repositories
{
    public class StockpriceRepository : IStockpriceRepository
    {
        private stockmarketdbContext db = new stockmarketdbContext();
        public bool CheckMissingData(int cmpcode, DateTime date)
        {
            //List<Stockprice> stockprices = new List<Stockprice>();
            //stockprices = (List<Stockprice>)db.Stockprice.Select(sp => sp.CompanyCode == cmpcode && sp.Date == date);
            int sp = new int();
            sp = db.Stockprice.Count(s => s.CompanyCode == cmpcode && s.Date == date);
            if(sp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Stockprice> GetStockprices()
        {
            List<Stockprice> stockprices = new List<Stockprice>();
            stockprices = db.Stockprice.ToList();
            if(stockprices != null)
            {
                return stockprices;
            }
            else
            {
                return null;
            }
        }
    }
}
