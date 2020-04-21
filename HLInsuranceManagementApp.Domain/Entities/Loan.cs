using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Domain.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int OrginalAmount { get; set; }
        public int RemainingAmount { get; set; }
        public int OrginalTenure { get; set; }
        public int RemainingTenure { get; set; }


        public int PropertyId { get; set; }
        public Property Property { get; set; }


        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public BuyPolicy BuyPolicy { get; set; }


    }
}
