using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_HRM.Common.VModels
{
    public class BaseVM
    {
        [Key]
        public int Id { get; set; }
    }
}
