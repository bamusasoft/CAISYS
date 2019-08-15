using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CAISYS.Controllers
{
    public class LedgerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}