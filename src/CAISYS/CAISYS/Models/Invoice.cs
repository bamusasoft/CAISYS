using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class Invoice
    {
        public int InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int CustomerAccount { get; set; }

        public decimal Total { get; set; }

        public decimal Discount { get; set; }

        public decimal Tax { get; set; }

        public decimal NetAmount { get; set; }

        public bool Posted { get; set; }
    }
}
