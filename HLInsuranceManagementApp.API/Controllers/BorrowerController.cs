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
    public class BorrowerController : ControllerBase
    {

        private readonly IBorrowerService _borrowerService;
        private readonly ILogger<BorrowerController> _logger;
        public BorrowerController(IBorrowerService borrowerService, 
            ILogger<BorrowerController> logger)
        {
            _borrowerService = borrowerService;
            _logger = logger;
        }


        /// <summary>
        /// Get Api to get all the borrowers
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        [Route("GetAllBorrowers")]
        public List<BorrowerDTO> GetAllBorrowers()
        {
            var borrowersList = new List<BorrowerDTO>();
            try
            {
                borrowersList = _borrowerService.GetAll();
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "Borrower", "GetAllBorrowers" } }))
                {
                    _logger.LogError(ex.Message);
                }
            }
            return borrowersList;
        }
    }
}