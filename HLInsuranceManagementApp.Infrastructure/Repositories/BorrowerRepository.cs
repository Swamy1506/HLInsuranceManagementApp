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
        public BorrowerRepository(DbContext context) : base(context)
        {
        }
    }
}
