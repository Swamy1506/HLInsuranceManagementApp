using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HLInsuranceManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {

        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowerController> _logger;
        public BorrowerController(IBorrowerRepository borrowerRepository, IMapper mapper, ILogger<BorrowerController> logger)
        {
            _borrowerRepository = borrowerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllBorrowers")]
        public List<BorrowerDTO> GetAllBorrowers()
        {
            var borrowersList = new List<BorrowerDTO>();
            try
            {
                borrowersList = _mapper.Map<List<Borrower>, List<BorrowerDTO>>(_borrowerRepository.GetAll());
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { { "Pages", "GetAllPages" } }))
                {
                    _logger.LogError(ex.Message);
                }

            }
            return borrowersList;
        }
    }
}