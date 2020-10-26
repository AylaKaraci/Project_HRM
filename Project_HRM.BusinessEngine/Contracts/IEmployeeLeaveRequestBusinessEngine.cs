using Project_HRM.Common.ResultModels;
using Project_HRM.Common.SessionOperations;
using Project_HRM.Common.VModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveRequestBusinessEngine
    {
        Result<List<EmployeeLeaveRequestVM>> GetAllLeaveRequestByUserId(string userId);
        Result<EmployeeLeaveRequestVM> CreateEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user);
        Result<EmployeeLeaveRequestVM> EditEmployeeLeaveRequest(EmployeeLeaveRequestVM model, SessionContext user);
        Result<EmployeeLeaveRequestVM> GetAllLeaveRequestById(int id);
        Result<EmployeeLeaveRequestVM> RemoveEmployeeRequest(int id);
        Result<List<EmployeeLeaveRequestVM>> GetSendApprovedLeaveRequests();//bu AssignControllerdan geldi. 
        Result<bool> RejectEmployeeLeaveRequest(int id);
    }
}
