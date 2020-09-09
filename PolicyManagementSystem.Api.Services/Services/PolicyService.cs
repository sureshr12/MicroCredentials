namespace PolicyManagementSystem.Api.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using PolicyManagementSystem.Api.Core.Domain;
    using PolicyManagementSystem.Api.Core.Model;
    using PolicyManagementSystem.Api.Core.Repository;

    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _repository;
        private readonly IMapper _mapper;

        public PolicyService(IPolicyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Policy> GetByIdAsync(string policyNumber)
        {
            return await _repository.GetByIdAsync(policyNumber);
        }

        public async Task<Policy> GetAsync(string policyNumber, string productType)
        {
            return await _repository.GetAsync(policyNumber, productType);
        }

        public async Task<string> AddAsync(PolicyModel policyModel)
        {
            var policy = _mapper.Map<PolicyModel, Policy>(policyModel);
            policy.Id = Guid.NewGuid().ToString();
            policy.PolicyNumber = DateTime.Now.ToString("yyyyMMddHHmmss");
            policy.CreatedDate = DateTime.Now;
            policy.CreatedBy = "admin";
            var response = await _repository.AddAsync(policy, policy.Postcode);
            if(response)
            {
                return policy.PolicyNumber;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(string id, string partitionKeyValue)
        {
            return await _repository.DeleteAsync(id, partitionKeyValue);
        }        

        public async Task<bool> UpdateAsync(string policyNumber, PolicyModel policyModel)
        {
            var result = await GetByIdAsync(policyNumber);
            var policy =  _mapper.Map(policyModel, result);
            policy.UpdatedDate = DateTime.Now;
            policy.UpdatedBy = "admin";
            return await _repository.UpdateAsync(policy);
        }      

    }
}
