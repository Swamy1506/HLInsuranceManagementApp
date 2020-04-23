using FluentValidation;
using FluentValidation.AspNetCore;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Application.Services.Implementations;
using HLInsuranceManagementApp.Application.Services.Interfaces;
using HLInsuranceManagementApp.Application.Validators;
using HLInsuranceManagementApp.Infrastructure;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using HLInsuranceManagementApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {

            // validations for api objects
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BorrowerRequestValidator>());

            // borrower
            services.AddScoped(typeof(IBorrowerRepository), typeof(BorrowerRepository));
            services.AddScoped(typeof(IBorrowerService), typeof(BorrowerService));

            // property
            services.AddScoped(typeof(IPropertyRepository), typeof(PropertyRepository));
            services.AddScoped(typeof(IPropertyService), typeof(PropertyService));

            // loan
            services.AddScoped(typeof(ILoanRepository), typeof(LoanRepository));
            services.AddScoped(typeof(ILoanService), typeof(LoanService));
            
            // buy policy to loan
            services.AddScoped(typeof(IBuyPolicyRepository), typeof(BuyPolicyRepository));
            services.AddScoped(typeof(IBuyPolicyService), typeof(BuyPolicyService));

            return services;

        }
    }
}
