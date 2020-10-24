using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_HRM.Common.ConstantsModels
{
    public enum EnumEmployeeLeaveRequestStatus
    {

        [Display(Name = "Onaya Gönderildi")]
        Send_Approved = 1,

        [Display(Name = "Onaylandı")]
        Approved = 2,

        [Display(Name = "Reddedildi")]
        Rejected = 3
    }
}
