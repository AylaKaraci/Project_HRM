using Project_HRM.Common.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveAssignBusinessEngine
    {
        Result<bool> ApprovedEmployeeRequest(int id);
    }
}
