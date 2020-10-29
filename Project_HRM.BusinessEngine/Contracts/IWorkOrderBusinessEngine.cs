using Project_HRM.Common.ResultModels;
using Project_HRM.Common.VModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Contracts
{
    public interface IWorkOrderBusinessEngine
    {
        Result<List<WorkOrderVM>> GetAllWorkOrders();       
        Result<WorkOrderVM> CreateWorkOrder(WorkOrderVM model, string uniqueFileName);
        Result<WorkOrderVM> GetWorkOrder(int id);
        Result<WorkOrderVM> EditWorkOrder(WorkOrderVM editModel);      
        Result<bool> RemoveWorkOrder(int id);
        Result<List<WorkOrderVM>> GetWorkOrderByEmployeeId(string employeeId);
    }
}
