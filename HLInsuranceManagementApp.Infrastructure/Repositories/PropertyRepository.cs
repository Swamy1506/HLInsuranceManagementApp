using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Infrastructure.Repositories
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        readonly HLIMDataContext _hLIMDataContext;

        public PropertyRepository(HLIMDataContext hLIMDataContext) : base(hLIMDataContext)
        {
            _hLIMDataContext = hLIMDataContext;
        }
    }
}
