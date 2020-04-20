using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Infrastructure.Repositories
{
    public class BorrowerRepository : Repository<Borrower>, IBorrowerRepository
    {
        readonly HLIMDataContext _hLIMDataContext;

        public BorrowerRepository(HLIMDataContext hLIMDataContext) : base(hLIMDataContext)
        {
            _hLIMDataContext = hLIMDataContext;
        }
    }
}
