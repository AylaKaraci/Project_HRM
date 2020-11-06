using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public  class EmployeeStatus : BaseEntity
    {
        public string EmployeeStatusName { get; set; }
    }
}
