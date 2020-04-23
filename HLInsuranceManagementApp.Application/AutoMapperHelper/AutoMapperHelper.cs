using AutoMapper;
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
            CreateMap<BorrowerDTO, Borrower>();
            CreateMap<Borrower, BorrowerDTO>();

            CreateMap<PropertyDTO, Property>();
            CreateMap<Property, PropertyDTO>();

            CreateMap<Bank, BankDTO>();
            CreateMap<BankDTO, Bank>();

            CreateMap<Loan, LoanDTO>();
            CreateMap<LoanDTO, Loan>();

            CreateMap<InsuranceCompanyDTO, InsuranceCompany>();
            CreateMap<InsuranceCompany, InsuranceCompanyDTO>();

            CreateMap<InsurancePolicyDTO, InsurancePolicy>();
            CreateMap<InsurancePolicy, InsurancePolicyDTO>();

            CreateMap<BuyPolicyDTO, BuyPolicy>();
            CreateMap<BuyPolicy, BuyPolicyDTO>();

        }
    }
}
