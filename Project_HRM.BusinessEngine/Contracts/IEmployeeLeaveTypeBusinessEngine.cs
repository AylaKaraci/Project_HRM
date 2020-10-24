using Project_HRM.Common.ResultModels;
using Project_HRM.Common.VModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes();
        Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model);
        Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model);
        Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id);
        Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id);
    }
}
