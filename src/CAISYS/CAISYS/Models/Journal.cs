using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class Journal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntryNo { get; set; }

        public DateTime EntryDate { get; set; }

        public string AccountNo { get; set; }

        public string Explanation { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public bool Posted { get; set; }

        public AccountChart AccountChart { get; set; }

        public ICollection<GeneralLedger> GeneralLedgers { get; set; }
    }
}
