using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_HRM.BusinessEngine.Contracts;

namespace Project_HRM.UI.Controllers
{
    public class EmployeeWorkOrderListController : Controller
    {
        private readonly IEmployeeBusinessEngine _employeeBusinessEngine;
        public IActionResult Index(int pageNumber = 1)
        {
            ViewBag.PageNumber = pageNumber;
            return View();
        }
    }
}