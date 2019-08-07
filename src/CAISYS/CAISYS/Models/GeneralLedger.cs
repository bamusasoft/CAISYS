using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class GeneralLedger
    {
        public string Id { get; set; }

        public int EntryNo { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }
    }
}
