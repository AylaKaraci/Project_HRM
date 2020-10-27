using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public class WorkOrderStatus : BaseEntity
    {
        [Required]
        public string WorkOrderStatusName { get; set; }
    }
}
