using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class Inventory
    {
        public string Id { get; set; }

        public string ProductCode { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal Cost { get; set; }

        public int QuantityIn { get; set; }

        public decimal TotalCost
        {
            get { return (QuantityIn * Cost); }
        }


        public int UnitsSold { get; set; }

        public int RemainedUnits
        {
            get
            {
                return (QuantityIn - UnitsSold);
            }
        }
        public decimal SellingPrice { get; set; }
    }
}
