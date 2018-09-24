using HammerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HammerProject.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            SalaryViewModel viewModel = new SalaryViewModel();
            return View(viewModel);
        }
    }
}