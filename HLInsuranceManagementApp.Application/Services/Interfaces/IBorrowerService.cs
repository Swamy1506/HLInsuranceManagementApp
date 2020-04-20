using HLInsuranceManagementApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Application.Services.Interfaces
{
    public interface IBorrowerService
    {
        Task<int> AddBorrower(BorrowerDTO entity);
    }
}
