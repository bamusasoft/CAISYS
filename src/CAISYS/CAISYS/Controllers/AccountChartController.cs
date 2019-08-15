using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAISYS.Db;
using CAISYS.Models;
using CAISYS.ViewModels.AccountChart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAISYS.Controllers
{
    public class AccountChartController : Controller
    {
        private readonly ILogger<AccountChartController> _logger;
        private readonly CaisysDbContext _dbContext;

        public AccountChartController(ILogger<AccountChartController> logger, CaisysDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAccount(string parent, AddAccountVm vm)
        {
            if (string.IsNullOrEmpty(parent))
            {
                throw new ArgumentNullException(parent);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AccountChart acc = new AccountChart();
                    acc.AccountLevel = vm.AccountLevel;
                    acc.AccountNo = vm.AccountNo;
                    acc.AccountType = vm.AccountType;
                    acc.CostCenter = vm.CostCenter;
                    acc.DetailAccount = vm.DetailAccount;

                    _dbContext.AccountCharts.Add(acc);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("New Account chart Added");

                    return View("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);

                }
            }
            return View(vm);

        }
    }
}