using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public class EmployeeLeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        //Çalışanla izin arasındaki ilişki, ne kadar izin tanımlanmış gibi.Employee ile birleştirilmesi gerekiyor.Her izin alanın bu tabloda tanımlanması gerekiyor.
        public string EmployeeId { get; set; } //string olmasının sebebi Identity prefixinden
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } //employee tablosuyla iletişime geçmem gerekiyor.

        //izin tipi de olması lazım:
        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }


    }
}
