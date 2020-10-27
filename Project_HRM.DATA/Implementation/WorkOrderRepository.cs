using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DataContext;
using Project_HRM.DATA.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.DATA.Implementation
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
    {
        private readonly ProjectContext _ctx;

        public WorkOrderRepository(ProjectContext ctx)
            : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
