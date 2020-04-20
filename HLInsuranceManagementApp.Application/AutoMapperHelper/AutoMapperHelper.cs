﻿using AutoMapper;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.AutoMapperHelper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<BorrowerDTO, Borrower>().ReverseMap();
            CreateMap<BorrowerDTO, Borrower>();
        }
    }
}
