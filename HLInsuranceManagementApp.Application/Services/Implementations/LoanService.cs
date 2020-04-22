using AutoMapper;
using HLInsuranceManagementApp.Application.Models;
using HLInsuranceManagementApp.Application.Services.Interfaces;
using HLInsuranceManagementApp.Domain.Entities;
using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {

        private readonly IMapper _mapper;
        private readonly ILoanRepository _repository;

        public LoanService(IMapper mapper, ILoanRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Add a loan to the system
        /// </summary>
        /// <param name="entity"></param>
        public async Task<int> Add(LoanDTO entity)
        {
            try
            {
                // call repository method to save loan
                var test = _mapper.Map<LoanDTO, Loan>(entity);
                return await _repository.Add(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adding collection of loans
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(List<LoanDTO> entities)
        {
            try
            {
                // call repository method to save collection of loans
                var collLoans = _mapper.Map<List<LoanDTO>, List<Loan>>(entities);

                _repository.AddRange(collLoans);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Loan by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LoanDTO Get(int id)
        {
            try
            {
                // call repository method to get loan by id
                var loan = _mapper.Map<Loan, LoanDTO>(_repository.Get(id));

                return loan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all loans from system
        /// </summary>
        /// <returns></returns>
        public List<LoanDTO> GetAll()
        {
            try
            {
                // call repository method to get all loans
                var loansList = _mapper.Map<List<Loan>, List<LoanDTO>>(_repository.GetAll());

                return loansList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Delete a loan
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(LoanDTO entity)
        {
            try
            {
                // call repository method to delete loan
                var selectedLoan = _mapper.Map<LoanDTO, Loan>(entity);
                _repository.Remove(selectedLoan);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Delete collection of loans
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(List<LoanDTO> entities)
        {
            try
            {
                // call repository method to delete collection of loans
                var selectedLoan = _mapper.Map<List<LoanDTO>, List<Loan>>(entities);
                _repository.RemoveRange(selectedLoan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
