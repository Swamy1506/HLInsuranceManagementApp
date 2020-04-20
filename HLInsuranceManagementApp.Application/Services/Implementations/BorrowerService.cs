using AutoMapper;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Application.Services.Interfaces;
using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Application.Services.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IMapper _mapper;
        private readonly IBorrowerRepository _repository;

        public BorrowerService(IMapper mapper, IBorrowerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Add a borrower to the system
        /// </summary>
        /// <param name="entity"></param>
        public void AddBorrower(BorrowerDTO entity)
        {
            try
            {
                // call repository method to save borrower
                var test = _mapper.Map<BorrowerDTO, Borrower>(entity);

                _repository.Add(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Get all borrowers from system
        /// </summary>
        /// <returns></returns>
        public List<BorrowerDTO> GetAll()
        {
            try
            {
                // call repository method to get all borrowers
                var borrowersList = _mapper.Map<List<Borrower>, List<BorrowerDTO>>(_repository.GetAll());

                return borrowersList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
