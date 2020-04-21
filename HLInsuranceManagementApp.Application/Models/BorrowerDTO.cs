﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Application.Models
{
    public class BorrowerDTO
    {

        public BorrowerDTO()
        {
            Properties = new List<PropertyDTO>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public IList<PropertyDTO> Properties { get; set; }
    }

    public class BorrowerValidator : AbstractValidator<BorrowerDTO>
    {
        public BorrowerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname shouldn't be empty");
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
