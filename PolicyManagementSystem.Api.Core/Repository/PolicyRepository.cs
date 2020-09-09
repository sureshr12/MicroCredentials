namespace PolicyManagementSystem.Api.Core.Repository
{
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Options;
    using PolicyManagementSystem.Api.Core.Domain;
    using PolicyManagementSystem.Api.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public class PolicyRepository : IPolicyRepository
    {
        private readonly IOptions<CosmosDbOptions> _cosmosDbOptions;
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public PolicyRepository(IOptions<CosmosDbOptions> cosmosDbOptions)
        {
            _cosmosDbOptions = cosmosDbOptions;
            _cosmosClient = new CosmosClient(_cosmosDbOptions.Value.Endpoint, _cosmosDbOptions.Value.Key);
            _container = _cosmosClient.GetContainer(_cosmosDbOptions.Value.DatabaseName, _cosmosDbOptions.Value.ContainerName);
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            var queryString = "SELECT * From c";

            var query = this._container.GetItemQueryIterator<Policy>(new QueryDefinition(queryString));
            List<Policy> results = new List<Policy>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<Policy> GetByIdAsync(string policyNumber)
        {
            var queryString = "SELECT * From c Where c.PolicyNumber = @policyNumber";

            var query = this._container.GetItemQueryIterator<Policy>(new QueryDefinition(queryString)
                                                                    .WithParameter("@policyNumber", policyNumber));
            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<Policy> GetAsync(string policyNumber, string productType)
        {
            var queryString = "SELECT * From c Where c.PolicyNumber = @policyNumber And c.ProductType = @productType";

            var query = this._container.GetItemQueryIterator<Policy>(new QueryDefinition(queryString)
                                                                    .WithParameter("@policyNumber", policyNumber)
                                                                    .WithParameter("@productType", productType));
            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<bool> AddAsync(Policy policy, string partitionKeyValue)
        {           
            var response = await this._container.CreateItemAsync<Policy>(policy, new PartitionKey(partitionKeyValue));
            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> DeleteAsync(string id, string partitionKeyValue)
        {
            var response = await this._container.DeleteItemAsync<Policy>(id, new PartitionKey(partitionKeyValue));
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> UpdateAsync(Policy policy)
        {            
            var response = await this._container.ReplaceItemAsync<Policy>(policy, policy.Id);
            return response.StatusCode == HttpStatusCode.OK;
        }        
    }
}
