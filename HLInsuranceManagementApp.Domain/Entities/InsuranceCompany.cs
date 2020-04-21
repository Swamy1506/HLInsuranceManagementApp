using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Domain.Entities
{
    public class InsuranceCompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public List<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
