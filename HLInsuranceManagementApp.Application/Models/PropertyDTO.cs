using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Models
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public int BorrowerId { get; set; }
        public BorrowerDTO Borrower { get; set; }
    }

    public class PropertyValidator : AbstractValidator<PropertyDTO>
    {
        public PropertyValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("The Address cannot be blank.");

            RuleFor(x => x.Type).NotEmpty().WithMessage("The Type cannot be blank.");

            RuleFor(x => x.BorrowerId).GreaterThan(0).WithMessage("The Borrower cannot be blank.");

        }
    }
}
