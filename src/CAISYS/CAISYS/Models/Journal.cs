using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class Journal
    {
        public int EntryNo { get; set; }

        public DateTime EntryDate { get; set; }

        public string AccountNo { get; set; }

        public string Explanation { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public bool Posted { get; set; }
    }
}
