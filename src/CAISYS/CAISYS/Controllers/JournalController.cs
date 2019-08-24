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
                var accounts = await _dbContext.AccountCharts.Where(x => x.DetailAccount).ToListAsync();
                AddEntryVm vm = new AddEntryVm();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEntry(AddEntryVm vm)
        {
            return View(vm);
        }
    }
}