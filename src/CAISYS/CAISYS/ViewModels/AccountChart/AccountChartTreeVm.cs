using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.ViewModels.AccountChart
{
    public class AccountChartTreeVm
    {
        public string AccountNo { get; set; }
        public string ParentNo { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsDetailAccount { get; set; }
        public int AccountLevel { get; set; }

    }
}
