using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAISYS.Core;
using CAISYS.Db;
using CAISYS.Models;
using CAISYS.Resources;
using CAISYS.ViewModels;
using CAISYS.ViewModels.AccountChart;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.DataProtection;
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
        private readonly IDataProtector _dataProtector;

        public AccountChartController(ILogger<AccountChartController> logger, CaisysDbContext dbContext, LocService localizer, IDataProtectionProvider provider)
        {
            _logger = logger;
            _dbContext = dbContext;
            _localizer = localizer;
            _dataProtector = provider.CreateProtector(GetType().FullName);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AccountChartTreeVm> vm = await GetAccountCharts();
            return View(vm);
        }



        [HttpGet]
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> PrintChartAccount()
        {
            List<AccountChartTreeVm> vm = await GetAccountCharts();
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);

            return View(vm);

        }
        [HttpGet]
        public IActionResult GetAccount(string v, CrudOp op)
        {
            switch (op)
            {
                case CrudOp.Add:
                    v = _dataProtector.Protect(v);
                    return RedirectToAction(nameof(AddAccount), new { v = v });
                case CrudOp.Edit:
                    v = _dataProtector.Protect(v);
                    return RedirectToAction(nameof(UpdateAccount), new { v = v });

                case CrudOp.Delete:
                    v = _dataProtector.Protect(v);
                    return RedirectToAction(nameof(ConfirmDelete), new { v = v });
            }
            string error = "There is error";
            return RedirectToAction("OperationResult", "Home", new { msg = error });

        }

        [HttpGet]
        public async Task<IActionResult> AddAccount(string v)
        {
            try
            {
                v = _dataProtector.Unprotect(v);
                var parent = await _dbContext.AccountCharts.FindAsync(v);
                if (parent != null)
                {
                    string maxAccNo = await _dbContext.AccountCharts.Where(x => x.ParentNo == parent.AccountNo).MaxAsync(x => x.AccountNo);

                    AccountChart model = new AccountChart();
                    model.AccountNo = IncrementAccountNo(maxAccNo, parent.AccountNo);
                    model.ParentNo = parent.AccountNo;
                    model.AccountType = parent.AccountType;
                    model.AccountLevel = ++parent.AccountLevel;

                    model.AccountTypes = model.LoadAccountTypes(_localizer);
                    v = _dataProtector.Protect(v);
                    return View(model);

                }
                string error = "There is error";
                return RedirectToAction("OperationResult", "Home", new { msg = error });


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
        public async Task<IActionResult> AddAccount(AccountChart model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.AccountCharts.Add(model);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("New Account chart Added");

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    string error = "There is error";
                    return RedirectToAction("OperationResult", "Home", new { msg = error });


                }
            }
            model.AccountTypes = model.LoadAccountTypes(_localizer);
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> UpdateAccount(string v)
        {
            try
            {
                var id = _dataProtector.Unprotect(v);
                var account = await _dbContext.AccountCharts.FindAsync(id);
                if (account != null)
                {
                    UpdateAccountVm model = new UpdateAccountVm();
                    model.AccountNo = account.AccountNo;
                    model.ParentNo = account.ParentNo;
                    model.NameAr = account.NameAr;
                    model.NameEn = account.NameEn;
                    model.DetailAccount = account.DetailAccount;
                    model.AccountLevel = account.AccountLevel;
                    model.CostCenter = account.CostCenter;
                    model.AccountType = account.AccountType;
                    model.AccountTypes = model.LoadAccountTypes(_localizer);
                    return View(model);
                }
                string error = "There is error";
                return RedirectToAction("OperationResult", "Home", new { msg = error });


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
        public async Task<IActionResult> UpdateAccount(UpdateAccountVm model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var account = await _dbContext.AccountCharts.FindAsync(model.AccountNo);
                    bool isValidUpdate = await IsValidAccountForUpdate(model);
                    if (!isValidUpdate)
                    {
                        return View(model);
                    }
                    if (account != null)
                    {
                        account.NameAr = model.NameAr;
                        account.NameEn = model.NameEn;
                        account.DetailAccount = model.DetailAccount;
                        account.CostCenter = model.CostCenter;
                        await _dbContext.SaveChangesAsync();

                        _logger.LogInformation("New Account chart Added");

                        return RedirectToAction("Index");
                    }
                    string error = "There is error";
                    return RedirectToAction("OperationResult", "Home", new { msg = error });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    string error = "There is error";
                    return RedirectToAction("OperationResult", "Home", new { msg = error });


                }
            }
            model.AccountTypes = model.LoadAccountTypes(_localizer);
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(string v)
        {
            try
            {
                var id = _dataProtector.Unprotect(v);
                var account = await _dbContext.AccountCharts.FindAsync(id);
                if (account != null)
                {
                    ConfirmDeleteVm model = new ConfirmDeleteVm();
                    model.Id = account.AccountNo;
                    model.Message = _localizer.GetLocalizedHtmlString("ConfirmDelete");
                    return View(model);
                }
                string error = "There is error";
                return RedirectToAction("OperationResult", "Home", new { msg = error });


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
        public async Task<IActionResult> ConfirmDelete(ConfirmDeleteVm model)
        {
            try
            {
                var account = await _dbContext.AccountCharts.FindAsync(model.Id);
                if (account != null)
                {
                    bool hasChildern = await AccountHasChildren(model.Id);
                    if (hasChildern)
                    {
                        ModelState.AddModelError("", _localizer.GetLocalizedHtmlString("AccountHasChildernError"));
                        return View(model);
                    }
                    bool hasEntries = await AccountHasJournalEntries(model.Id);
                    if (hasEntries)
                    {
                        ModelState.AddModelError("", _localizer.GetLocalizedHtmlString("AccountHasEntriesError"));
                        return View(model);
                    }
                    hasEntries = await AccountHasLedgerEntries(model.Id);
                    if (hasEntries)
                    {
                        ModelState.AddModelError("", _localizer.GetLocalizedHtmlString("AccountHasEntriesError"));
                        return View(model);
                    }

                    _dbContext.AccountCharts.Remove(account);

                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("An account deleted");

                    return RedirectToAction("Index");
                }
                string error = "There is error";
                return RedirectToAction("OperationResult", "Home", new { msg = error });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                string error = "There is error";
                return RedirectToAction("OperationResult", "Home", new { msg = error });
            }
        }



        #region Helper
        private async Task<List<AccountChartTreeVm>> GetAccountCharts()
        {
            var accountCharts = await _dbContext.AccountCharts.OrderBy(x => x.AccountNo).ToListAsync();
            List<AccountChartTreeVm> vm = new List<AccountChartTreeVm>();
            accountCharts.ForEach(x =>
            {
                vm.Add(new AccountChartTreeVm()
                {
                    AccountNo = x.AccountNo.Trim(),
                    ParentNo = x.ParentNo.Trim(),
                    NameAr = x.NameAr.Trim(),
                    NameEn = x.NameEn.Trim(),
                    IsDetailAccount = x.DetailAccount,
                    AccountLevel = x.AccountLevel

                });
            }
            );
            return vm;
        }

        private string IncrementAccountNo(string maxAccNo, string parentAccount)
        {
            if (!string.IsNullOrWhiteSpace(maxAccNo))
            {
                int i;
                if (int.TryParse(maxAccNo, out i))
                {
                    i++;
                    return i.ToString();
                }

            }

            return $"{parentAccount}{1}";

        }
        private async Task<bool> IsValidAccountForUpdate(UpdateAccountVm model)
        {
            if (model.DetailAccount)
            {

                var hasChildern = await _dbContext.AccountCharts.AnyAsync(x => x.ParentNo == model.AccountNo);
                if (hasChildern)
                {
                    ModelState.AddModelError("DetailAccount", _localizer.GetLocalizedHtmlString("AccountHasChildernError"));
                    return false;

                }

            }
            if (!model.DetailAccount)
            {
                if (await _dbContext.Journals.AnyAsync(x => x.AccountNo == model.AccountNo))
                {
                    ModelState.AddModelError("DetailAccount", _localizer.GetLocalizedHtmlString("AccountHasEntriesError"));
                    return false;
                }
                if (await AccountHasLedgerEntries(model.AccountNo))
                {
                    ModelState.AddModelError("DetailAccount", _localizer.GetLocalizedHtmlString("AccountHasEntriesError"));
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> AccountHasLedgerEntries(string accountNo)
        {
            return await _dbContext.GeneralLedgers.AnyAsync(x => x.AccountNo == accountNo);
        }

        private async Task<bool> AccountHasJournalEntries(string accountNo)
        {
            return await _dbContext.Journals.AnyAsync(x => x.AccountNo == accountNo);
        }

        private async Task<bool> AccountHasChildren(string accountNo)
        {
            return await _dbContext.AccountCharts.AnyAsync(x => x.ParentNo == accountNo);
        }
        #endregion
    }
}