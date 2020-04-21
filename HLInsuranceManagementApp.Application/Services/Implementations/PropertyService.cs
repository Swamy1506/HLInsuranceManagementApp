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
    public class PropertyService: IPropertyService
    {
        private readonly IMapper _mapper;
        private readonly IPropertyRepository _repository;

        public PropertyService(IMapper mapper, IPropertyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Add a property to the system
        /// </summary>
        /// <param name="entity"></param>
        public async Task<int> Add(PropertyDTO entity)
        {
            try
            {
                // call repository method to save property
                var test = _mapper.Map<PropertyDTO, Property>(entity);
                return await _repository.Add(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// adding collection of property
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(List<PropertyDTO> entities)
        {
            try
            {
                // call repository method to save collection of property
                var collProperties = _mapper.Map<List<PropertyDTO>, List<Property>>(entities);

                _repository.AddRange(collProperties);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Property by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PropertyDTO Get(int id)
        {
            try
            {
                // call repository method to get property by id
                var property = _mapper.Map<Property, PropertyDTO>(_repository.Get(id));

                return property;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all properties from system
        /// </summary>
        /// <returns></returns>
        public List<PropertyDTO> GetAll()
        {
            try
            {
                // call repository method to get all properties
                var propertiesList = _mapper.Map<List<Property>, List<PropertyDTO>>(_repository.GetAll());

                return propertiesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Delete a property
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(PropertyDTO entity)
        {
            try
            {
                // call repository method to delete property
                var selectedProperty = _mapper.Map<PropertyDTO, Property>(entity);
                _repository.Remove(selectedProperty);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return isDeleted;
        }

        /// <summary>
        /// Delete collection of properties
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(List<PropertyDTO> entities)
        {
            try
            {
                // call repository method to delete collection of properties
                var selectedProperties = _mapper.Map<List<PropertyDTO>, List<Property>>(entities);
                _repository.RemoveRange(selectedProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
