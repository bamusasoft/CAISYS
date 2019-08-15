using System;
using System.Collections.Generic;
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
        public string AccountNo { get; set; }
        public string ParentNo { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public AccountType AccountType { get; set; }
        public bool DetailAccount { get; set; }
        public int AccountLevel { get; set; }

        public int CostCenter { get; set; }
        
        public ICollection<GeneralLedger> GeneralLedgers { get; set; }
        public ICollection<Journal> Journals { get; set; }


    }
}
