using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class GeneralLedger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Id { get; set; }

        public int EntryNo { get; set; }

        public string AccountNo { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public AccountChart AccountChart { get; set; }

        public Journal Journal { get; set; }
    }
}
