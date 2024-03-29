﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.PaginatedListModels;
using Project_HRM.Common.SessionOperations;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.DbModels;

namespace Project_HRM.UI.Controllers
{
    public class EmployeeController : Controller
    {
       
        private readonly IEmployeeBusinessEngine _employeeBusinessEngine;
        private readonly IEmployeeLeaveRequestBusinessEngine _employeeLeaveRequestBusinessEngine;

        private readonly IHostingEnvironment _hostingEnvironment;

        public EmployeeController(IEmployeeBusinessEngine employeeBusinessEngine, IHostingEnvironment hostingEnvironment, IEmployeeLeaveRequestBusinessEngine employeeLeaveRequestBusinessEngine)
        {
            
            _employeeBusinessEngine = employeeBusinessEngine;
            _hostingEnvironment = hostingEnvironment;
            _employeeLeaveRequestBusinessEngine = employeeLeaveRequestBusinessEngine;
        }

        public IActionResult Index(string employeeId, int pageNumber = 1)
        {
            
            if (!String.IsNullOrWhiteSpace(employeeId))
            {
                var dataWithEmployee = _employeeBusinessEngine.GetNewByEmployeeId(employeeId);

                var model = PaginatedList<EmployeeVM>.CreateAsync(dataWithEmployee.Data, pageNumber, 15);
                

                return View(model);
            }

            var data = _employeeBusinessEngine.GetAllNewEmployees();

        
            if (data.IsSuccess)
            {
                var model = PaginatedList<EmployeeVM>.CreateAsync(data.Data, pageNumber, 3);
                return View(model);
            }
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }


 

        [HttpPost]
        public ActionResult Create(EmployeeVM model)
        {
            if (ModelState.IsValid)
            {

                var data = _employeeBusinessEngine.CreateNewEmployee(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
                return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return View();

            var data = _employeeBusinessEngine.GetAllEditEmployee(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(EmployeeVM model)
        {
          
                var data = _employeeBusinessEngine.EditEmployeeType(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
           
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            if (id == null)
                return View();

            var data = _employeeBusinessEngine.GetAllEditEmployee(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }



        [HttpDelete]
        public IActionResult Delete(string id)
        {

            if (id == null)
                return View();

            var data = _employeeBusinessEngine.RemoveEmployee(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        



            //if (id == null)
            //    return Json(new { success = false, message = "Silmek için kayıt seçiniz..." });

            //var data = _employeeBusinessEngine.RemoveEmployee(id);

            //if (data.IsSuccess)
            //    return Json(new { success = data.IsSuccess, message = data.Message });
            //else
            //    return Json(new { success = data.IsSuccess, message = data.Message });


        }
    }
}