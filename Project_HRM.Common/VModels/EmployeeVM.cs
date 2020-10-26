using Project_HRM.DATA.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_HRM.Common.VModels
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }
        public string Document { get; set; }
        public string TaxId { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfWork { get; set; }//işe giriş tarihi
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

    
     
    }
}
