using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Infrastructure.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(HLIMDataContext context) : base(context)
        {
        }
    }
}
