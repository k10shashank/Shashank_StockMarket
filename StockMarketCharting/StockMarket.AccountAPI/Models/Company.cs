using System;
using System.Collections.Generic;

namespace StockMarket.AccountAPI.Models
{
    public partial class Company
    {
        public Company()
        {
            Stockprice = new HashSet<Stockprice>();
        }

        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public double? Turnover { get; set; }
        public string Ceo { get; set; }
        public string BoardDirector { get; set; }
        public string ListedStockExchange { get; set; }
        public int? SectorId { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual ICollection<Stockprice> Stockprice { get; set; }
    }
}
