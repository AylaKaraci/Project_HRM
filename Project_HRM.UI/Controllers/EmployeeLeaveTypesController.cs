using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.VModels;

namespace Project_HRM.UI.Controllers
{
    public class EmployeeLeaveTypesController : Controller
    {
        private readonly IEmployeeLeaveTypeBusinessEngine _employeeLeaveTypeBusinessEngine;


        public EmployeeLeaveTypesController(IEmployeeLeaveTypeBusinessEngine employeeLeaveTypeBusinessEngine)
        {
            _employeeLeaveTypeBusinessEngine = employeeLeaveTypeBusinessEngine;
        }


        public IActionResult Index()
        {
            var data = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if (data.IsSuccess)
            {
                var result = data.Data;
                return View(result);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeLeaveTypeVM model)
        {
            if (ModelState.IsValid) //gelen model doğru mu?
            {
                var data = _employeeLeaveTypeBusinessEngine.CreateEmployeeLeaveType(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id < 0)
                return View();
            var data = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveType(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }

        [ValidateAntiForgeryToken]//get çağrılmadan post yapılamaz.
        [HttpPost]
        public ActionResult Edit(EmployeeLeaveTypeVM model)
        {
            if (ModelState.IsValid) //gelen model doğru mu?
            {
                var data = _employeeLeaveTypeBusinessEngine.EditEmployeeLeaveType(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            else
                return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Silmek için kayıt seçiniz..." });

            var data = _employeeLeaveTypeBusinessEngine.RemoveEmployeeLeaveType(id);
            if (data.IsSuccess)
                return Json(new { success = data.IsSuccess, message = data.Message });
            else
                return Json(new { success = data.IsSuccess, message = data.Message });


        }
    }
}