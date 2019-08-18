using CAISYS.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Asset = 1,
        Liablility = 2,
        Equity = 3,
        Revenue = 4,
        Expense = 5
    }
    public class AccountChart
    {
        private readonly LocService _localizer;

        public AccountChart() { }

        
        #region Database Table mapping

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
        #endregion

        [NotMapped]
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
