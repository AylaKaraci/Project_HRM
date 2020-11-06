using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.SessionOperations;
using Project_HRM.Common.VModels;

namespace Project_HRM.UI.Controllers
{
    public class EmployeeLeaveRequestController : Controller
    {

        #region Variables

        private readonly IEmployeeLeaveRequestBusinessEngine _employeeLeaveRequestBusinessEngine;
        private readonly IEmployeeLeaveTypeBusinessEngine _employeeLeaveTypeBusinessEngine; 
        #endregion

        #region Constructor
        public EmployeeLeaveRequestController(IEmployeeLeaveRequestBusinessEngine employeeLeaveRequestBusinessEngine, IEmployeeLeaveTypeBusinessEngine employeeLeaveTypeBusinessEngine)
        {
            _employeeLeaveRequestBusinessEngine = employeeLeaveRequestBusinessEngine;
            _employeeLeaveTypeBusinessEngine = employeeLeaveTypeBusinessEngine;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(ResultConstant.LoginUserInfo));

            var requestModel = _employeeLeaveRequestBusinessEngine.GetAllLeaveRequestByUserId(user.LoginId);
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if (requestModel.IsSuccess)
                return View(requestModel.Data);

            return View(user);
        }

        public IActionResult Create()
        {
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeLeaveRequestVM model, int? id)
        {
            var user = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(ResultConstant.LoginUserInfo));

            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.EditEmployeeLeaveRequest(model, user);
                return RedirectToAction("Index");
            }
            else
            {
                var data = _employeeLeaveRequestBusinessEngine.CreateEmployeeLeaveRequest(model, user);
                if (data.IsSuccess)
                    return RedirectToAction("Index");
                return View(model);
            }

        }

        public ActionResult Edit(int? id)
        {
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes().Data;
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.GetAllLeaveRequestById((int)id);
                return View(data.Data);
            }
            else
                return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Silmek için Kayıt Seçiniz" });

            var data = _employeeLeaveRequestBusinessEngine.RemoveEmployeeRequest(id);
            if (data.IsSuccess)
                return Json(new { success = data.IsSuccess, message = data.Message });
            else
                return Json(new { success = data.IsSuccess, message = data.Message });
        }

        public ActionResult Reject(int id)
        {
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.RejectEmployeeLeaveRequest((int)id);
                return RedirectToAction("Index", "EmployeeLeaveAssign");
            }
            else
                return View();
        }

        public ActionResult Confirm(int id)
        {
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.ConfirmEmployeeLeaveRequest((int)id);
                return RedirectToAction("Index", "EmployeeLeaveAssign");
            }
            else
                return View();
        }

        #endregion
    }
}