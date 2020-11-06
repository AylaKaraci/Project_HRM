using AutoMapper;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.Extension;
using Project_HRM.Common.ResultModels;
using Project_HRM.Common.SessionOperations;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DbModels;
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

        public Result<EmployeeLeaveRequestVM> CreateEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user)
        {
            if (model != null)
            {
                try
                {
                    var leaveRequest = _mapper.Map<EmployeeLeaveRequestVM, EmployeeLeaveRequest>(model);
                    leaveRequest.RequestingEmployeeId = user.LoginId;
                    leaveRequest.Cancelled = false;
                    leaveRequest.Approved = (int)EnumEmployeeLeaveRequestStatus.Send_Approved;
                    leaveRequest.DateRequested = DateTime.Now;
                    _unitOfWork.employeeLeaveRequestRepository.Add(leaveRequest);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveRequestVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveRequestVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveRequestVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }
        public Result<EmployeeLeaveRequestVM> EditEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user)
        {
            if (model != null)
            {
                try
                {
                    var leaveRequest = _mapper.Map<EmployeeLeaveRequestVM, EmployeeLeaveRequest>(model);
                    leaveRequest.Approved = (int)model.ApprovedStatus;
                    leaveRequest.RequestingEmployeeId = user.LoginId;
                    _unitOfWork.employeeLeaveRequestRepository.Update(leaveRequest);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveRequestVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveRequestVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveRequestVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        public Result<EmployeeLeaveRequestVM> GetAllLeaveRequestById(int id)
        {
            var data = _unitOfWork.employeeLeaveRequestRepository.Get(id);
            if (data != null)
            {
                var leaveRequest = _mapper.Map<EmployeeLeaveRequest, EmployeeLeaveRequestVM>(data);
                leaveRequest.ApprovedStatus = (EnumEmployeeLeaveRequestStatus)data.Approved;
                leaveRequest.ApprovedText = EnumExtension<EnumEmployeeLeaveRequestStatus>.GetDisplayValue((EnumEmployeeLeaveRequestStatus)data.Approved);
                return new Result<EmployeeLeaveRequestVM>(true, ResultConstant.RecordFound, leaveRequest);
            }
            else
                return new Result<EmployeeLeaveRequestVM>(false, ResultConstant.RecordNotFound);
        }

        public Result<EmployeeLeaveRequestVM> RemoveEmployeeRequest(int id)
        {
            var data = _unitOfWork.employeeLeaveRequestRepository.Get(id);
            if (data != null)
            {
                data.Cancelled = true;
                _unitOfWork.employeeLeaveRequestRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveRequestVM>(true, ResultConstant.RecordCreateSuccessfully);
            }
            else
                return new Result<EmployeeLeaveRequestVM>(false, ResultConstant.RecordCreateNotSuccessfully);
        }

        public Result<List<EmployeeLeaveRequestVM>> GetSendApprovedLeaveRequests()
        {
            var data = _unitOfWork.employeeLeaveRequestRepository.GetAll(
                u => u.Approved == (int)EnumEmployeeLeaveRequestStatus.Send_Approved
                && u.Cancelled == false,
                includeProperties: "RequestingEmployee,EmployeeLeaveType").ToList();

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
                        RequestingEmployeeId = item.RequestingEmployeeId,
                        RequestEmployeeName = item.RequestingEmployee.Email
                    });
                }
                return new Result<List<EmployeeLeaveRequestVM>>(true, ResultConstant.RecordFound, returnData);
            }
            else
                return new Result<List<EmployeeLeaveRequestVM>>(false, ResultConstant.RecordNotFound);
        }

        public Result<bool> RejectEmployeeLeaveRequest(int id)
        {
            var data = _unitOfWork.employeeLeaveRequestRepository.Get(id);
            if (data != null)
            {
                try
                {
                    data.Approved = (int)EnumEmployeeLeaveRequestStatus.Rejected;
                    _unitOfWork.employeeLeaveRequestRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<bool>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<bool>(false, ex.Message.ToString());
                }
            }
            else
                return new Result<bool>(false, ResultConstant.RecordCreateNotSuccessfully);
        }

        public Result<bool> ConfirmEmployeeLeaveRequest(int id)
        {
            var data = _unitOfWork.employeeLeaveRequestRepository.Get(id);
            if (data != null)
            {
                try
                {
                    data.Approved = (int)EnumEmployeeLeaveRequestStatus.Approved;
                    _unitOfWork.employeeLeaveRequestRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<bool>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<bool>(false, ex.Message.ToString());
                }
            }
            else
                return new Result<bool>(false, ResultConstant.RecordCreateNotSuccessfully);
        }


        #endregion
    }
}
