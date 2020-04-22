using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Models
{
    public class BuyPolicyDTO
    {
        public int TransactionId { get; set; }

        public int LoanId { get; set; }
        public LoanDTO Loan { get; set; }

        public int PolicyId { get; set; }
        public InsurancePolicyDTO Policy { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
