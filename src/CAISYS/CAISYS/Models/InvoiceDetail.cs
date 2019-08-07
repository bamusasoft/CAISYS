using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class InvoiceDetail
    {
        public string DetailId { get; set; }

        public int InvoiceNo { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total
        {
            get
            {

                return (Quantity * Price);
            }
        }
    }
}
