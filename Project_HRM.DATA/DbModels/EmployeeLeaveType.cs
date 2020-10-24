using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public class EmployeeLeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
