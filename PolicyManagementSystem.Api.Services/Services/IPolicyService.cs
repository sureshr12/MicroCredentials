namespace PolicyManagementSystem.Api.Services.Services
{       
    using System.Collections.Generic;   
    using System.Threading.Tasks;
    using PolicyManagementSystem.Api.Core.Domain;
    using PolicyManagementSystem.Api.Core.Model;

    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetAllAsync();
        Task<Policy> GetByIdAsync(string policyNumber);
        Task<Policy> GetAsync(string policyNumber, string productType);
        Task<string> AddAsync(PolicyModel policy);
        Task<bool> UpdateAsync(string policyNumber, PolicyModel policy);
        Task<bool> DeleteAsync(string id, string partitionKeyValue);
    }
}
