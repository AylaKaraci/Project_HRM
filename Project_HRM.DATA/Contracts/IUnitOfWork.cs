using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.DATA.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeLeaveAllocationRepository employeeAllocationRepository { get; }
        IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; }
        IEmployeeLeaveTypeRepository employeeTypeRepository { get; }
       

        void Save();
    }
}
