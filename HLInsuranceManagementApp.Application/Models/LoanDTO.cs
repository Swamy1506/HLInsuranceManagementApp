using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Models
{
    public class LoanDTO
    {

        public int Id { get; set; }
        public int OrginalAmount { get; set; }
        public int? RemainingAmount { get; set; }
        public int OrginalTenure { get; set; }
        public int? RemainingTenure { get; set; }

        public int PropertyId { get; set; }
        public PropertyDTO Property { get; set; }

        public int BankId { get; set; }
        public BankDTO Bank { get; set; }

        //public BuyPolicy BuyPolicy { get; set; }


    }

    public class LoanValidator : AbstractValidator<LoanDTO>
    {
        public LoanValidator()
        {
            RuleFor(x => x.OrginalAmount).GreaterThan(0).WithMessage("The OrginalAmount cannot be blank.");

            RuleFor(x => x.OrginalTenure).GreaterThan(0).WithMessage("The OrginalTenure cannot be blank.");

            RuleFor(x => x.PropertyId).GreaterThan(0).WithMessage("The Property cannot be blank.");

            RuleFor(x => x.BankId).GreaterThan(0).WithMessage("The BankId cannot be blank.");
        }
    }
}
