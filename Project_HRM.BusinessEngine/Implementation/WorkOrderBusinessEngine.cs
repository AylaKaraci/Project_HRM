using AutoMapper;
using Project_HRM.BusinessEngine.Contracts;
using Project_HRM.DATA.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_HRM.BusinessEngine.Implementation
{
    public class WorkOrderBusinessEngine : IWorkOrderBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkOrderBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion
    }
}
