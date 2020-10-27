using Project_HRM.Common.ResultModels;
using Project_HRM.Common.VModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Contracts
{
    public interface IEmployeeBusinessEngine
    {
        Result<List<EmployeeVM>> GetNewByEmployeeId(string employeeId);
        Result<List<EmployeeVM>> GetAllNewEmployees();
        Result<EmployeeVM> CreateNewEmployee(EmployeeVM model);      
        Result<EmployeeVM> EditEmployeeType(EmployeeVM model);
        Result<EmployeeVM> GetAllEditEmployee(string id);
        Result<List<EmployeeVM>> GetAllEmployee();//workorder edit işlemi için
    }
}
