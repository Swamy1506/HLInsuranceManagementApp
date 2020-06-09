using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HLInsuranceManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {

        private readonly ILoanService _loanService;
        private readonly ILogger<LoanController> _logger;
        public LoanController(ILoanService loanService,
            ILogger<LoanController> logger)
        {
            _loanService = loanService;
            _logger = logger;
        }

        /// <summary>
        /// Get Api to get all the loans
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAllLoans")]
        public List<LoanDTO> GetAllBorrowers()
        {
            var loans = new List<LoanDTO>();
            try
            {
                loans = _loanService.GetAll();
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "Loan", "GetAllLoans" } }))
                {
                    _logger.LogError(ex.Message);
                }
                throw ex;
            }
            return loans;
        }

        /// <summary>
        /// save loan information
        /// </summary>
        /// <param name="loanInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveLoan")]
        [ValidateFilter]
        public async Task<int> SaveBorrower([FromBody] LoanDTO loanInfo)
        {
            int loanId = 0;
            try
            {
                loanId = await _loanService.Add(loanInfo);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "Loan", "SaveLoan" } }))
                {
                    _logger.LogError(ex.Message);
                }
                throw ex;
            }
            return loanId;

        }

    }
}