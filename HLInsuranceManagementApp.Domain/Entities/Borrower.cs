using HLInsuranceManagementApp.Domain.Common;
using HLInsuranceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Domain.Entities
{
    public class Borrower : AuditEntity
    {
        public Borrower()
        {
            Properties = new List<Property>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public IList<Property> Properties { get; set; }

    }
}
