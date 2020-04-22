using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Infrastructure.Repositories
{
    public class BuyPolicyRepository : Repository<BuyPolicy>, IBuyPolicyRepository
    {
        public BuyPolicyRepository(HLIMDataContext context) : base(context)
        {
        }
    }
}
