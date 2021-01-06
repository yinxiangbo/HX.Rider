using AutoMapper;
using HX.Rider.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Service
{
    public class BaseService
    {
        #region DI
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public BaseService(ILogger logger,IMapper mapper)
        {
            this.Logger = logger;
            this.Mapper = mapper;
        }
        #endregion
    }
}
