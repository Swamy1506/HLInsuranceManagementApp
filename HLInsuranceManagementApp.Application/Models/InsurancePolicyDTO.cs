using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Models
{
    public class InsurancePolicyDTO
    {
        public int PolicyId { get; set; }
        public int PremiumAmount { get; set; }
        public int Tenure { get; set; }
        public int CompanyId { get; set; }
        public InsuranceCompanyDTO Company { get; set; }
    }
}
