using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAISYS.Db;
using CAISYS.Models;
using CAISYS.Resources;
using CAISYS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CAISYS.Controllers
{
    public class AccountChartController : Controller
    {
        private readonly ILogger<AccountChartController> _logger;
        private readonly CaisysDbContext _dbContext;
        private readonly LocService _localizer;

        public AccountChartController(ILogger<AccountChartController> logger, CaisysDbContext dbContext, LocService localizer)
        {
            _logger = logger;
            _dbContext = dbContext;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            var accountCharts = await _dbContext.AccountCharts.ToListAsync();
            List<AccountChartTreeVm> vm = new List<AccountChartTreeVm>();
            accountCharts.ForEach(x =>
            {
                vm.Add(new AccountChartTreeVm()
                {
                    AccountNo = x.AccountNo.Trim(),
                    ParentNo = x.ParentNo.Trim(),
                    Name = x.NameAr
                });
            }
            );
            return View(vm);
        }
        [HttpGet]
        public IActionResult AddAccount()
        {
            AccountChart model = new AccountChart(_localizer);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountChart model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    _dbContext.AccountCharts.Add(model);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("New Account chart Added");

                    return View("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);

                }
            }
            return View(model);

        }
    }
}