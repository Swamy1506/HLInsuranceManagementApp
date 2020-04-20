using HLInsuranceManagementApp.Application.Services.Implementations;
using HLInsuranceManagementApp.Application.Services.Interfaces;
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
            services.AddDbContext<HLIMDataContext>(ServiceLifetime.Scoped);

            // borrower
            services.AddScoped(typeof(IBorrowerRepository), typeof(BorrowerRepository));
            services.AddScoped(typeof(IBorrowerService), typeof(BorrowerService));


            return services;

        }
    }
}
