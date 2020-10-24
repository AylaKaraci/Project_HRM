using AutoMapper;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.Common.ConstantsModels;
using Project_HRM.Common.ResultModels;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_HRM.BusinessEngine.Implementation
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Custom Methods
        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.GetAll(e => e.IsActive == true).ToList();
            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data); // EmployeeType ı EmployeeLeaveTypeVM e çevir dedik.

            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes);

        }

        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    leaveType.IsActive = true;
                    _unitOfWork.employeeLeaveTypeRepository.Add(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {

                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        public Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    _unitOfWork.employeeLeaveTypeRepository.Update(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {

                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        public Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                var leaveType = _mapper.Map<EmployeeLeaveType, EmployeeLeaveTypeVM>(data);
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordFound, leaveType);
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordNotFound);
        }

        public Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                data.IsActive = false;
                _unitOfWork.employeeLeaveTypeRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully);
        }

        #endregion
    }
}
