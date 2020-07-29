using System;
using System.Collections.Generic;

namespace StockMarket.ExcelAPI.Models
{
    public partial class Stockexchange
    {
        public Stockexchange()
        {
            Stockprice = new HashSet<Stockprice>();
        }

        public int StockExchangeId { get; set; }
        public string StockExchangeName { get; set; }
        public string Brief { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<Stockprice> Stockprice { get; set; }
    }
}
