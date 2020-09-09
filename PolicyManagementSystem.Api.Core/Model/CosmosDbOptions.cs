namespace PolicyManagementSystem.Api.Core.Model
{
    public class CosmosDbOptions
    {
        public string DatabaseName { get; set; }

        public string Key { get; set; }

        public string Endpoint { get; set; }

        public string ContainerName { get; set; }
    }
}
