using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Domain.Entities
{
   public class BuyPolicy
    {
        public int Id { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public int PolicyId { get; set; }
        public InsurancePolicy Policy { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
