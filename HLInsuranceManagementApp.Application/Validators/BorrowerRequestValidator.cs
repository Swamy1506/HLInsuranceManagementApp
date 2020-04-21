using FluentValidation;
using HLInsuranceManagementApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Validators
{
    public class BorrowerRequestValidator : AbstractValidator<BorrowerDTO>
    {
        public BorrowerRequestValidator()
        {
        }
    }
}
