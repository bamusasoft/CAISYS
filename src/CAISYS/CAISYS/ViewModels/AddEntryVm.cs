using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CAISYS.Models;

namespace CAISYS.ViewModels
{
    public class AddEntryVm
    {
        public AddEntryVm()
        {
            Entries = new List<EntryItem>();
        }
        public int EntryNo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime EntryDate { get; set; }

        

        [Required]
        public bool Posted { get; set; }

        public List<EntryItem> Entries
        {
            get;set;
        }

        public void AddAccountCharts(List<AccountChart> accounts)
        {
            for(int i = 0; i < 11; i++)
            {
                Entries.Add(new EntryItem()
                {
                    AccountCharts = new List<SelectListItem>()
                });
            }
            foreach (var entry in Entries)
            {
                accounts.ForEach(x =>
                {
                    entry.AccountCharts.Add(new SelectListItem(x.NameAr, x.AccountNo));
                });
            }
           
        }

    }
    public class EntryItem
    {
        [Required]
        public string AccountNo { get; set; }

        [Required]
        public string Explanation { get; set; }

        [Required]
        public decimal Debit { get; set; }

        [Required]
        public decimal Credit { get; set; }

        public AccountChart AccountChart { get; set; }

        public List<SelectListItem> AccountCharts { get; set; }


    }
}
