using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_HRM.Common.VModels;
using Project_HRM.DATA.Contracts;
using Project_HRM.DATA.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project_HRM.UI.ViewComponents
{
    public class UserNameViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserNameViewComponent(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userFromDb = _uow.employeeRepository.GetFirstOrDefault(u => u.Id == claims.Value);

            var employeeToDb = _mapper.Map<Employee, EmployeeVM>(userFromDb);

            return View(employeeToDb);
        }
    }
}
