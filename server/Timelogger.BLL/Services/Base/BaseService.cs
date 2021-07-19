using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Timelogger.DAL.Base;
using Timelogger.DAL.UnitOfWork;

namespace Timelogger.BLL.Services.Base
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
