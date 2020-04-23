using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Models
{
    public class BuyPolicyDTO
    {
        public int Id { get; set; }

        public int LoanId { get; set; }
        public LoanDTO Loan { get; set; }

        public int PolicyId { get; set; }
        public InsurancePolicyDTO Policy { get; set; }

        public DateTime? ExpireDate { get; set; }
    }

    public class BuyPolicyValidator : AbstractValidator<BuyPolicyDTO>
    {
        public BuyPolicyValidator()
        {
            RuleFor(x => x.LoanId).GreaterThan(0).WithMessage("The Loan cannot be blank.");

            RuleFor(x => x.PolicyId).GreaterThan(0).WithMessage("The Policy cannot be blank.");

        }
    }
}
