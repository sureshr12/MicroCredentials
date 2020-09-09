namespace PolicyManagementSystem.Api.Core.Repository
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using PolicyManagementSystem.Api.Core.Domain;

    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetAllAsync();
        Task<Policy> GetByIdAsync(string policyNumber);
        Task<Policy> GetAsync(string policyNumber, string productType);
        Task<bool> AddAsync(Policy policy, string partitionKeyValue);
        Task<bool> UpdateAsync(Policy policy);
        Task<bool> DeleteAsync(string id, string partitionKeyValue);
    }
}
