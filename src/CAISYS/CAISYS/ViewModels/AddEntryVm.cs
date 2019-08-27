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
        public DateTime EntryDate { get; set; }



        [Required]
        public bool Posted { get; set; }

        public List<EntryItem> Entries
        {
            get; set;
        }

        public void AddAccountCharts(List<AccountChart> accounts)
        {
            
            for (int i = 0; i < 10; i++)
            {
                Entries.Add(new EntryItem()
                {
                    AccountCharts = new List<SelectListItem>()
                });
            }
            foreach (var entry in Entries)
            {
                entry.AccountCharts.Add(new SelectListItem("Choose Account", "-1"));
                accounts.ForEach(x =>
                {
                    entry.AccountCharts.Add(new SelectListItem(x.NameAr, x.AccountNo));
                });
            }

        }
        public void RefreshAccountCharts(List<AccountChart> accounts)
        {
            foreach (var entry in Entries)
            {
                entry.AccountCharts = new List<SelectListItem>();
                entry.AccountCharts.Add(new SelectListItem("Choose Account", "-1"));

                accounts.ForEach(x =>
                {
                    entry.AccountCharts.Add(new SelectListItem(x.NameAr, x.AccountNo));
                });
            }
        }

    }
    public class EntryItem
    {
        public string AccountNo { get; set; }

        public string Explanation { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public List<SelectListItem> AccountCharts { get; set; }


    }
}
