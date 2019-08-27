using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CAISYS.Db;
using CAISYS.Models;
using CAISYS.Resources;
using CAISYS.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CAISYS.Controllers
{
    public class JournalController : Controller
    {
        private readonly ILogger<AccountChartController> _logger;
        private readonly CaisysDbContext _dbContext;
        private readonly LocService _localizer;
        private readonly IDataProtector _dataProtector;

        public JournalController(ILogger<AccountChartController> logger, CaisysDbContext dbContext, LocService localizer, IDataProtectionProvider provider)
        {
            _logger = logger;
            _dbContext = dbContext;
            _localizer = localizer;
            _dataProtector = provider.CreateProtector(GetType().FullName);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddEntry()
        {

            try
            {
                List<AccountChart> accounts = await GetAccounts();
                var vm = new AddEntryVm();
                vm.EntryDate = DateTime.Now;
                vm.AddAccountCharts(accounts);

                return View(vm);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                string error = "There is error";
                return RedirectToAction("OperationResult", "Home", new { msg = error });
            }


        }

        private async Task<List<AccountChart>> GetAccounts()
        {
            return await _dbContext.AccountCharts.Where(x => x.DetailAccount).ToListAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEntry(AddEntryVm vm)
        {

            if (ModelState.IsValid)
            {
              
                var debitSum = vm.Entries.Sum(x => x.Debit);
                var creditSum = vm.Entries.Sum(x => x.Credit);
                if(debitSum != creditSum)
                {
                    ModelState.AddModelError("", "Sum of Debit must equal Sum of Credit");
                    vm.RefreshAccountCharts(await GetAccounts());
                    return View(vm);
                }
                bool isValid = true;
                List<EntryItem> entries = new List<EntryItem>();
                foreach (var entry in vm.Entries)
                {
                   
                    if (entry.AccountNo != "-1")
                    {
                        if (string.IsNullOrEmpty(entry.Explanation))
                        {
                            ModelState.AddModelError("", "Enter Explanation");
                            isValid = false;
                        }
                        if(entry.Debit <= 0 && entry.Credit <= 0)
                        {
                            ModelState.AddModelError("", "Debit or credit amount must be greater thant 0");
                            isValid = false;
                        }
                        
                        if (!isValid)
                        {

                            vm.RefreshAccountCharts(await GetAccounts());
                            return View(vm);
                        }

                        entries.Add(entry);
                        
                    }
                    
                }

                foreach (var entry in entries)
                {
                    var journal = new Journal();
                    journal.EntryNo = new Random().Next(1, 10000);
                    journal.EntryDate = vm.EntryDate;
                    journal.AccountNo = entry.AccountNo;
                    journal.Explanation = entry.Explanation;
                    journal.Debit = entry.Debit;
                    journal.Credit = entry.Credit;

                    _dbContext.Add(journal);
                }
               await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            vm.RefreshAccountCharts(await GetAccounts());
            return View(vm);
        }
        



    }
}