using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public class WorkOrder : BaseEntity
    {
        #region Properteis

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(750)]
        public string WorkOrderDescription { get; set; }

        public int WorkOrderStatus { get; set; }

        public double WorkOrderPoint { get; set; }//işemri puanı.en az işi olana iş atanacak
        public string PhotoPath { get; set; }

        [MaxLength(35)]
        public string WorkOrderNumber { get; set; }

        public string AssignEmployeeId { get; set; } //kim tarafından atandı
        [ForeignKey("AssignEmployeeId")]
        public Employee AssignEmployee { get; set; }
        #endregion
    }
}
