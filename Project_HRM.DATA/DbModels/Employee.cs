using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.DATA.DbModels
{
    public class Employee : IdentityUser //AspNetUser tablosu genişletildi
    {
        public string FirstName { get; set; }
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
