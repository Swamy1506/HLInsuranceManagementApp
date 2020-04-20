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
        public async Task<int> Add(BorrowerDTO entity)
        {
            try
            {
                // call repository method to save borrower
                var test = _mapper.Map<BorrowerDTO, Borrower>(entity);
              return  await _repository.Add(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// adding collection of borrowers
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(List<BorrowerDTO> entities)
        {
            try
            {
                // call repository method to save collection of borrowers
                var collBorrowers = _mapper.Map<List<BorrowerDTO>, List<Borrower>>(entities);

                _repository.AddRange(collBorrowers);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Borrower by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BorrowerDTO Get(int id)
        {
            try
            {
                // call repository method to get borrower by id
                var borrower = _mapper.Map<Borrower, BorrowerDTO>(_repository.Get(id));

                return borrower;
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

        /// <summary>
        /// Delete a borrower
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(BorrowerDTO entity)
        {
            try
            {
                // call repository method to delete borrower
                var selectedBorrower = _mapper.Map<BorrowerDTO, Borrower>(entity);
                _repository.Remove(selectedBorrower);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return isDeleted;
        }

        /// <summary>
        /// Delete collection of borrowers
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(List<BorrowerDTO> entities)
        {
            try
            {
                // call repository method to delete collection of borrowers
                var selectedBorrowers = _mapper.Map<List<BorrowerDTO>, List<Borrower>>(entities);
                _repository.RemoveRange(selectedBorrowers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
