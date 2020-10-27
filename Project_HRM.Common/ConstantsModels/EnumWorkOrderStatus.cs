using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_HRM.Common.ConstantsModels
{
    public enum EnumWorkOrderStatus
    {
        [Display(Name = "İş Emri Oluşturuldu")]
        WorkOrder_Created = 1,

        [Display(Name = "Atandı")]
        Assigned = 2,

        [Display(Name = "Üstlenildi")]
        Undertake = 3,

        [Display(Name = "Kapatıldı")]
        Closed = 4
    }
}
