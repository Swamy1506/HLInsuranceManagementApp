using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Domain.Entities
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public int PremiumAmount { get; set; }
        public int Tenure { get; set; }
        public int CompanyId { get; set; }
        public InsuranceCompany Company { get; set; }
    }
}
