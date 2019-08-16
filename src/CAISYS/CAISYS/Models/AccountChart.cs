using CAISYS.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public enum AccountType
    {
        Asset = 0,
        Liablility = 1,
        Equity = 2,
        Revenue = 3,
        Expense = 4
    }
    public class AccountChart
    {

        [Key]
        [Required(ErrorMessage ="AccountNoRequired")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AccountNo { get; set; }

        [Required]
        public string ParentNo { get; set; }

        [Required]
        public string NameAr { get; set; }

        [Required]
        public string NameEn { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public bool DetailAccount { get; set; }

        [Required]
        public int AccountLevel { get; set; }

        [Required]
        public int CostCenter { get; set; } = 0; //Defaulted to 0. When you support cost centers change this.
        
        public ICollection<GeneralLedger> GeneralLedgers { get; set; }
        public ICollection<Journal> Journals { get; set; }


    }
}
