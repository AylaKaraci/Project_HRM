using AutoMapper;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.ResultModels;
using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Implementation
{
    public class EmployeeLeaveAssignBusinessEngine : IEmployeeLeaveAssignBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeLeaveAssignBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #endregion

        #region CustomMethods

        public Result<bool> ApprovedEmployeeRequest(int id)
        {
            if (id > 0)
            {
                try
                {
                    var data = _unitOfWork.employeeLeaveRequestRepository.GetFirstOrDefault(u => u.Id == id);
                    if (data != null)
                    {
                        EmployeeLeaveAllocation createModel = new EmployeeLeaveAllocation();
                        createModel.DateCreated = DateTime.Now;
                        createModel.EmployeeId = data.RequestingEmployeeId;
                        createModel.EmployeeLeaveTypeId = data.EmployeeLeaveTypeId;
                        var day = (data.EndDate.Day - data.StartDate.Day);
                        createModel.NumberOfDays = day < 0 ? -day : day;
                        createModel.Period = 1;
                        _unitOfWork.employeeAllocationRepository.Add(createModel);

                    }

                    data.Approved = (int)EnumEmployeeLeaveRequestStatus.Approved;
                    _unitOfWork.employeeLeaveRequestRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<bool>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<bool>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<bool>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        #endregion
    }
}
