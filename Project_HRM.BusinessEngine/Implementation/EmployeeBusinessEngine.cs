using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class EmployeeBusinessEngine : IEmployeeBusinessEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #region Constructor
        public EmployeeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Methods
      
        public Result<List<EmployeeVM>> GetAllNewEmployees()
        {
            var data = _unitOfWork.employeeRepository.GetAll();

            if (data != null)
            {
                List<EmployeeVM> returnData = new List<EmployeeVM>();
                foreach (var item in data)
                {
                    returnData.Add(new EmployeeVM()
                    {
                        Id = item.Id,
                 
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        TcNo = item.TcNo,
                        Address = item.Address,
                        Gender = item.Gender,
                        Document = item.Document,
                        MaritalStatus = item.MaritalStatus,
                        PhoneNumber = item.PhoneNumber,
                        DateOfBirth = item.DateOfBirth,
                        DateOfWork = item.DateOfWork,
                        Email = item.Email
                    });
                }
                return new Result<List<EmployeeVM>>(true, ResultConstant.RecordFound, returnData.OrderByDescending(x => x.FirstName).ToList());
            }
            else
                return new Result<List<EmployeeVM>>(false, ResultConstant.RecordNotFound);
        }
        public Result<List<EmployeeVM>> GetNewByEmployeeId(string employeeId)
        {
            throw new NotImplementedException();
        }
        public Result<EmployeeVM> CreateNewEmployee(EmployeeVM model)
        {
            if (model != null)
            {
                try
                {
                    var employee = _mapper.Map<EmployeeVM, Employee>(model);
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.TcNo = model.TcNo;
                    employee.Address = model.Address;
                    employee.Gender = model.Gender;
                    //employee.Photo = model.Photo.ToString();
                    employee.Document = model.Document;
                    employee.MaritalStatus = model.MaritalStatus;
                    employee.PhoneNumber = model.PhoneNumber;
                    employee.DateOfBirth = model.DateOfBirth;
                    employee.DateOfWork = model.DateOfWork;
                    employee.TcNo = model.TcNo;
                    //employee.Email = model.Email;

                    _unitOfWork.employeeRepository.Add(employee);
                    _unitOfWork.Save();
                    return new Result<EmployeeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        public Result<EmployeeVM> GetAllEditEmployee(string id)
        {
            var data = _unitOfWork.employeeRepository.Get(id);
            if (data != null)
            {
                var leaveType = _mapper.Map<Employee, EmployeeVM>(data);
                return new Result<EmployeeVM>(true, ResultConstant.RecordFound, leaveType);
            }
            else
                return new Result<EmployeeVM>(false, ResultConstant.RecordNotFound);
        }

        public Result<EmployeeVM> EditEmployeeType(EmployeeVM model)
        {
            if (model.Id != null)
            {
                var data = _unitOfWork.employeeRepository.Get(model.Id);
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.TcNo = model.TcNo;
                    data.DateOfBirth = model.DateOfBirth;
                    data.PhoneNumber = model.PhoneNumber;
                    data.Email = model.Email;
                    data.MaritalStatus = model.MaritalStatus;
                    data.DateOfWork = model.DateOfWork;
                    data.Address = model.Address;
                    data.PhotoPath = model.PhotoPath;


                    _unitOfWork.employeeRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<EmployeeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                else
                    return new Result<EmployeeVM>(false, "Lütfen Güncelleme İşlemi İçin Data Seçiniz");
            }
            else
                return new Result<EmployeeVM>(false, "Lütfen Güncelleme İşlemi İçin Data Seçiniz");







            //if (model != null)
            //{
            //    try
            //    {
            //        var edit = _mapper.Map<EmployeeVM, Employee>(model);
            //        _unitOfWork.employeeRepository.Update(edit);
            //        _unitOfWork.Save();
            //        return new Result<EmployeeVM>(true, ResultConstant.RecordCreateSuccessfully);
            //    }
            //    catch (Exception ex)
            //    {
            //        return new Result<EmployeeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
            //    }
            //}
            //else
            //    return new Result<EmployeeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

       




        #endregion
    }
}
