using CAISYS.Models;
using CAISYS.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.ViewModels.AccountChart
{
    public class UpdateAccountVm
    {
        [Required(ErrorMessage = "AccountNoRequired")]
        public string AccountNo { get; set; }

        public string ParentNo { get; set; }

        [Required]
        public string NameAr { get; set; }

        [Required]
        public string NameEn { get; set; }

        public AccountType AccountType { get; set; }

        [Required]
        public bool DetailAccount { get; set; }

        public int AccountLevel { get; set; }

        [Required]
        public int CostCenter { get; set; } = 0;


        public List<SelectListItem> AccountTypes { get; set; }
        public List<SelectListItem> LoadAccountTypes(LocService localizer)
        {
            AccountTypes = new List<SelectListItem>()
            {
                new SelectListItem(localizer.GetLocalizedHtmlString("Asset"), "1"),
                new SelectListItem(localizer.GetLocalizedHtmlString("Liability"), "2"),
                new SelectListItem(localizer.GetLocalizedHtmlString("Equity"), "3"),
                new SelectListItem(localizer.GetLocalizedHtmlString("Revenue"), "4"),
                new SelectListItem(localizer.GetLocalizedHtmlString("Expense"), "5"),
            };
            return AccountTypes;
        }
    }
}
