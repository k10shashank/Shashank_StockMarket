using System;
using System.Collections.Generic;

namespace StockMarket.UserAPI.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Company = new HashSet<Company>();
        }

        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public string Brief { get; set; }

        public virtual ICollection<Company> Company { get; set; }
    }
}
