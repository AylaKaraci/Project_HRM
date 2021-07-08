using Microsoft.AspNetCore.Http;
using Project_HRM.Common.ConstantsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_HRM.Common.VModels
{
    public class WorkOrderVM : BaseVM
    {
        #region Properties
        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(750)]
        public string WorkOrderDescription { get; set; }

        public EnumWorkOrderStatus WorkOrderStatus { get; set; }

        public string WorkOrderStatusText { get; set; }

        [Required]
        public double WorkOrderPoint { get; set; }

        [MaxLength(35)]
        public string WorkOrderNumber { get; set; }

        public IFormFile PhotoPath { get; set; }
        public string PhotoPathText { get; set; }
        public string AssignEmployeeName { get; set; }
        public string AssignEmployeeId { get; set; }

        [ForeignKey("AssignEmployeeId")]
        public EmployeeVM AssignEmployee { get; set; }

   
        public EmployeeVM IsActive { get; set; }
        #endregion
    }
}

