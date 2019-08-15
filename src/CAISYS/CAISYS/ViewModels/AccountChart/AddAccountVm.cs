using CAISYS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.ViewModels
{
    public class AddAccountVm
    {
        public string AccountNo { get; set; }
        public string ParentNo { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public AccountType AccountType { get; set; }
        public bool DetailAccount { get; set; }
        public int AccountLevel { get; set; }

        public int CostCenter { get; set; }

    }
}
