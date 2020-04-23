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
    public class PropertyController : ControllerBase
    {

        private readonly IPropertyService _propertyService;
        private readonly ILogger<PropertyController> _logger;
        public PropertyController(IPropertyService propertyService,
            ILogger<PropertyController> logger)
        {
            _propertyService = propertyService;
            _logger = logger;
        }

        /// <summary>
        /// Get Api to get all the borrowers
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAllProperties")]
        public List<PropertyDTO> GetAllBorrowers()
        {
            try
            {
                return _propertyService.GetAll();
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "Property", "GetAllProperties" } }))
                {
                    _logger.LogError(ex.Message);
                }
                throw ex;
            }
        }

        /// <summary>
        /// save property information
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveProperty")]
        [ValidateFilter]
        public async Task<int> SaveProperty([FromBody] PropertyDTO propertyInfo)
        {
            try
            {
                return await _propertyService.Add(propertyInfo);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "Property", "SaveProperty" } }))
                {
                    _logger.LogError(ex.Message);
                }
                throw ex;
            }

        }

    }
}
