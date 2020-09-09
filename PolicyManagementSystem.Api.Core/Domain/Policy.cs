namespace PolicyManagementSystem.Api.Core.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Policy
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string PolicyNumber { get; set; }
      
        public string Title { get; set; }
      
        public string FirstName { get; set; }
        
        public string SurName { get; set; }

        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }
       
        public string Address { get; set; }

        public string Postcode { get; set; }

        public string ProductType { get; set; }
      
        public string CoverType { get; set; }
       
        public decimal SumAssured { get; set; }
        
        public decimal MonthlyPremium { get; set; }  
        
        public UnderwritingQuestions UnderwritingQuestions { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
