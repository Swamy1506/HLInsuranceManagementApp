using AutoMapper;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Application.Services.Interfaces;
using HLInsuranceManagementApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Application.Services.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IMapper _mapper;

        public BorrowerService(IMapper mapper, HLIMDataContext dbContext)
        {
            _mapper = mapper;
        }

        public Task<int> AddBorrower(BorrowerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
