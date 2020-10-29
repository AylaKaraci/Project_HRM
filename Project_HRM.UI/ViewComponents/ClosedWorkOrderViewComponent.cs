using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.PaginatedListModels;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project_HRM.UI.ViewComponents
{
    public class ClosedWorkOrderViewComponent : ViewComponent
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClosedWorkOrderViewComponent(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        #endregion

        #region CustomMethod

        public async Task<IViewComponentResult> InvokeAsync(int pageNumber = 1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userFromDb = _uow.employeeRepository.GetFirstOrDefault(u => u.Id == claims.Value);
            var employeeId = userFromDb.Id;
            var workOrderStatus = (int)EnumWorkOrderStatus.Closed;
            var data = _uow.workOrderRepository
                            .GetAll(u => u.AssignEmployeeId == employeeId && u.WorkOrderStatus == workOrderStatus).ToList();


            if (data != null)
            {
                List<WorkOrderVM> returnData = new List<WorkOrderVM>();
                foreach (var item in data)
                {
                    returnData.Add(new WorkOrderVM
                    {
                        AssignEmployeeName = item.AssignEmployee.Email,
                        WorkOrderNumber = item.WorkOrderNumber,
                        WorkOrderPoint = item.WorkOrderPoint,
                        WorkOrderDescription = item.WorkOrderDescription,
                        CreateDate = item.CreateDate,
                        ModifiedDate = item.ModifiedDate,
                        Id = item.Id,
                        AssignEmployeeId = item.AssignEmployeeId
                    });
                }
                var model = PaginatedList<WorkOrderVM>.CreateAsync(returnData, pageNumber, 5);
                return View(model);
            }
            return View();
        }
        #endregion
    }
}
