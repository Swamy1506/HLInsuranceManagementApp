using HLInsuranceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLInsuranceManagementApp.Infrastructure.SeedData
{
    public class Seed
    {
        public static void SeedData(HLIMDataContext context)
        {

            if (!context.Banks.Any())
            {
                var banks = new List<Bank>()
                {
                    new Bank()
                    {
                        Name = "SBI"
                    },
                    new Bank()
                    {
                        Name = "HDFC"
                    },
                    new Bank()
                    {
                        Name = "ICICI"
                    }
                };
                context.Banks.AddRange(banks);
            }

            if (!context.InsuranceCompanies.Any())
            {
                var banks = new List<InsuranceCompany>()
                {
                    new InsuranceCompany()
                    {
                        CompanyName = "SBILife"
                    },
                    new InsuranceCompany()
                    {
                        CompanyName = "HDFCLife"
                    },
                    new InsuranceCompany()
                    {
                        CompanyName = "ICICILife"
                    },
                };
                context.InsuranceCompanies.AddRange(banks);
                context.SaveChanges();
            }

            if (!context.InsuranceCompanies.Any())
            {
                var companies = new List<InsuranceCompany>()
                {
                    new InsuranceCompany()
                    {
                        CompanyName = "SBILife"
                    },
                    new InsuranceCompany()
                    {
                        CompanyName = "HDFCLife"
                    },
                    new InsuranceCompany()
                    {
                        CompanyName = "ICICILife"
                    },
                };
                context.InsuranceCompanies.AddRange(companies);
                context.SaveChanges();
            }

            if (!context.InsurancePolicies.Any())
            {
                var policies = new List<InsurancePolicy>()
                                    {
                                        new InsurancePolicy()
                                        {
                                            PremiumAmount = 10000,
                                            Tenure = 10,
                                            CompanyId =1
                                        },
                                        new InsurancePolicy()
                                        {
                                            PremiumAmount = 12000,
                                            Tenure = 8,
                                            CompanyId =1
                                        },
                                        new InsurancePolicy()
                                        {
                                           PremiumAmount = 8000,
                                           Tenure = 13,
                                           CompanyId =1
                                        }
                                    };
                context.InsurancePolicies.AddRange(policies);
                context.SaveChanges();
            }

        }
    }
}
