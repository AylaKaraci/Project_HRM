using AutoMapper;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.Extension;
using Project_HRM.Common.ResultModels;
using Project_HRM.Common.SessionOperations;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_HRM.BusinessEngine.Implementation
{
    public class EmployeeLeaveRequestBusinessEngine : IEmployeeLeaveRequestBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeLeaveRequestBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region CustomMethods

        public Result<List<EmployeeLeaveRequestVM>> GetAllLeaveRequestByUserId(string userId)
        {
            var data = _unitOfWork.employeeLeaveRequestRepository.GetAll(
               u => u.RequestingEmployeeId == userId
               && u.Cancelled == false,
               includeProperties: "RequestingEmployee,EmployeeLeaveType").ToList();
            //bana getirirken RequestingEmployee,EmployeeLeaveType bu iki bilgiyi de getir.
            if (data != null)
            {
                List<EmployeeLeaveRequestVM> returnData = new List<EmployeeLeaveRequestVM>();
                foreach (var item in data)
                {
                    returnData.Add(new EmployeeLeaveRequestVM()
                    {
                        Id = item.Id,
                        ApprovedStatus = (EnumEmployeeLeaveRequestStatus)item.Approved,
                        ApprovedText = EnumExtension<EnumEmployeeLeaveRequestStatus>.GetDisplayValue((EnumEmployeeLeaveRequestStatus)item.Approved),
                        ApprovedEmployeeId = item.ApprovedEmployeeId,
                        Cancelled = item.Cancelled,
                        DateRequested = item.DateRequested,
                        EmployeeLeaveTypeId = item.EmployeeLeaveTypeId,
                        LeaveTypeText = item.EmployeeLeaveType.Name,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                        RequestComments = item.RequestComments,
                        RequestingEmployeeId = item.RequestingEmployeeId

                    });
                }
                return new Result<List<EmployeeLeaveRequestVM>>(true, ResultConstant.RecordFound, returnData);
            }
            else
                return new Result<List<EmployeeLeaveRequestVM>>(false, ResultConstant.RecordNotFound);

        }

        public object CreateEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user)
        {
            throw new NotImplementedException();
        }

        public object EditEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user)
        {
            throw new NotImplementedException();
        }

        public object GetAllLeaveRequestById(int id)
        {
            throw new NotImplementedException();
        }
        public object RejectEmployeeLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public object RemoveEmployeeRequest(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
