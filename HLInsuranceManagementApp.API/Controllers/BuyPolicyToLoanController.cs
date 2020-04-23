using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HLInsuranceManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyPolicyToLoanController : ControllerBase
    {
        private readonly IBuyPolicyService _buyPolicyService;
        private readonly ILogger<BuyPolicyToLoanController> _logger;
        public BuyPolicyToLoanController(IBuyPolicyService buyPolicyService,
            ILogger<BuyPolicyToLoanController> logger)
        {
            _buyPolicyService = buyPolicyService;
            _logger = logger;
        }

        /// <summary>
        /// Api to get all the polycies bought
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAllLoanPolicies")]
        public List<BuyPolicyDTO> GetAllLoanPolicies()
        {
            var policies = new List<BuyPolicyDTO>();
            try
            {
                policies = _buyPolicyService.GetAll();
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "BuyPolicy", "GetAllLoanPolicies" } }))
                {
                    _logger.LogError(ex.Message);
                }
            }
            return policies;
        }

        /// <summary>
        /// Add policy to loan
        /// </summary>
        /// <param name="policyInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveLoanPolicy")]
        [ValidateFilter]
        public async Task<int> SaveLoanPolicy([FromBody] BuyPolicyDTO policyInfo)
        {
            int createdId = 0;
            try
            {
                createdId = await _buyPolicyService.Add(policyInfo);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "BuyPolicy", "SaveLoanPolicy" } }))
                {
                    _logger.LogError(ex.Message);
                }

            }
            return createdId;

        }
    }
}