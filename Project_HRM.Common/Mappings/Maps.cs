using AutoMapper;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.Common.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<EmployeeLeaveType, EmployeeLeaveTypeVM>().ReverseMap();
            CreateMap<EmployeeLeaveAllocation, EmployeeLeaveAllocationsVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<EmployeeLeaveRequest, EmployeeLeaveRequestVM>().ReverseMap();
            
            //Employee'ı EmployeeVM ye dönüştür demiş olduk. vb.
        }
    }
}
