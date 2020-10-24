using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.Common.ResultModels
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
