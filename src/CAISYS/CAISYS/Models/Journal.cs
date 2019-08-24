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

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public string AccountNo { get; set; }

        [Required]
        public string Explanation { get; set; }

        [Required]
        public decimal Debit { get; set; }

        [Required]
        public decimal Credit { get; set; }

        [Required]
        public bool Posted { get; set; }

        public AccountChart AccountChart { get; set; }

        public ICollection<GeneralLedger> GeneralLedgers { get; set; }
    }
}
