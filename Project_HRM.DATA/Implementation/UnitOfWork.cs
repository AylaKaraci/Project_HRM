using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.DATA.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _ctx;

        #region Constructor
        public UnitOfWork(ProjectContext ctx)
        {
            _ctx = ctx;
            employeeAllocationRepository = new EmployeeLeaveAllocationRepository(_ctx);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_ctx);
            employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_ctx);
            employeeRepository = new EmployeeRepository(_ctx);
            workOrderRepository = new WorkOrderRepository(_ctx);

        }
        #endregion

        #region Properties
        public IEmployeeLeaveAllocationRepository employeeAllocationRepository { get; private set; } //dışarıdan set edilmesin.Ben yukarıda set ettim.
        //TODO: diğer interfaceleri de yap.
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }

        public IEmployeeRepository employeeRepository { get; private set; }
        public IWorkOrderRepository workOrderRepository { get; private set; }


        #endregion

        #region Save Dispos Methods
        public void Save()
        {
            _ctx.SaveChanges();
        }
        public void Dispose()
        {
            _ctx.Dispose(); //işin bitince bunu at remi şişirme
        }
        #endregion
    }
}
