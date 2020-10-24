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
            employeeTypeRepository = new EmployeeLeaveTypeRepository(_ctx);
      
        }
        #endregion

        #region Properties
        public IEmployeeLeaveAllocationRepository employeeAllocationRepository { get; private set; } //dışarıdan set edilmesin.Ben yukarıda set ettim.
        //TODO: diğer interfaceleri de yap.
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository employeeTypeRepository { get; private set; }



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
