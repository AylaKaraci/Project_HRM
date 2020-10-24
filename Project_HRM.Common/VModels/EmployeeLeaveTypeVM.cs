using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_HRM.Common.VModels
{
    public class EmployeeLeaveTypeVM : BaseVM
    {
        [Required]
        public string Name { get; set; }//ekleme-silme-güncellemede zorunlu
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        //MVVM Create EmployeeType
        public void SetEmployeeType(string name)
        {
            this.Name = name;
        }
    }
}
