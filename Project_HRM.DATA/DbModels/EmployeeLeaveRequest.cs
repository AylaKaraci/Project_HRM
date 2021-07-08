using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public class EmployeeLeaveRequest : BaseEntity
    {

        //Talepte Bulunan Kullanıcı Bilgileri
        public string RequestingEmployeeId { get; set; } //employee nin tipi string di.
        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }//istekte bulunan kişi.


        //Onaylayan Kullanıcı Bilgileri
        public string ApprovedEmployeeId { get; set; } //employee nin tipi string di.

        [ForeignKey("ApprovedEmployeeId")]
        public Employee ApprovedEmployee { get; set; }


        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }//bununla talepte bulunacağım.

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }//not için
        public int? Approved { get; set; }
        public bool? Cancelled { get; set; }



    }
}
