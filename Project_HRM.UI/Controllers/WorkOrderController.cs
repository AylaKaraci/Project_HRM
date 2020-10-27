using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.PaginatedListModels;
using Project_HRM.Common.VModels;

namespace Project_HRM.UI.Controllers
{
    public class WorkOrderController : Controller
    {
        #region Variables
        private readonly IWorkOrderBusinessEngine _workOrderBusinessEngine;
        private readonly IEmployeeBusinessEngine _employeeBusinessEngine;
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        [System.Obsolete]
        public WorkOrderController(IWorkOrderBusinessEngine workOrderBusinessEngine, IEmployeeBusinessEngine employeeBusinessEngine, IHostingEnvironment hostingEnvironment)
        {
            _workOrderBusinessEngine = workOrderBusinessEngine;
            _employeeBusinessEngine = employeeBusinessEngine;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Actions
        public IActionResult Index(string employeeId, int pageNumber = 1)
        {
            if (!String.IsNullOrWhiteSpace(employeeId))
            {
                var dataWithEmployee = _workOrderBusinessEngine.GetWorkOrderByEmployeeId(employeeId);
                var model = PaginatedList<WorkOrderVM>.CreateAsync(dataWithEmployee.Data, pageNumber, 5);
                return View(model);
            }
            var data = _workOrderBusinessEngine.GetAllWorkOrders();
            if (data.IsSuccess)
            {
                var model = PaginatedList<WorkOrderVM>.CreateAsync(data.Data, pageNumber, 5);
                return View(model);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkOrderVM model)
        {
            string uniqueFileName = null;
            if (model.PhotoPath != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CustomImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            var result = _workOrderBusinessEngine.CreateWorkOrder(model, uniqueFileName);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View();
        }
        #endregion
    }
}