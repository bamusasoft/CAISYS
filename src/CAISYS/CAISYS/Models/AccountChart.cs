using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class AccountChart
    {
        public string AccountNo { get; set; }
        public string ParentNo { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int AccountType { get; set; }
        public bool DetailAccount { get; set; }
        public int AccountLevel { get; set; }

        public int CostCenter { get; set; }
        


    }
}
