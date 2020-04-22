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
    public class BuyPolicyService : IBuyPolicyService
    {
        private readonly IMapper _mapper;
        private readonly IBuyPolicyRepository _repository;

        public BuyPolicyService(IMapper mapper, IBuyPolicyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Add method to add policy
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Add(BuyPolicyDTO entity)
        {
            try
            {
                // call repository method to add policy
                var test = _mapper.Map<BuyPolicyDTO, BuyPolicy>(entity);
                return await _repository.Add(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add collection of polycies
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(List<BuyPolicyDTO> entities)
        {
            try
            {
                // call repository method to add policies
                var collPolicies = _mapper.Map<List<BuyPolicyDTO>, List<BuyPolicy>>(entities);

                _repository.AddRange(collPolicies);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get BuyPolicy by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BuyPolicyDTO Get(int id)
        {
            try
            {
                // call repository method to get policy
                var policyData = _mapper.Map<BuyPolicy, BuyPolicyDTO>(_repository.Get(id));

                return policyData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all policies sold
        /// </summary>
        /// <returns></returns>
        public List<BuyPolicyDTO> GetAll()
        {
            try
            {
                // call repository method to get all policies sold
                var policiesList = _mapper.Map<List<BuyPolicy>, List<BuyPolicyDTO>>(_repository.GetAll());

                return policiesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Delete a policy
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(BuyPolicyDTO entity)
        {
            try
            {
                // call repository method to delete policy
                var selectedPolicy = _mapper.Map<BuyPolicyDTO, BuyPolicy>(entity);
                _repository.Remove(selectedPolicy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete collection of policies sold
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(List<BuyPolicyDTO> entities)
        {
            try
            {
                // call repository method to delete collection of policies
                var selectedPolicies = _mapper.Map<List<BuyPolicyDTO>, List<BuyPolicy>>(entities);
                _repository.RemoveRange(selectedPolicies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
