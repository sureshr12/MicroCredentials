namespace PolicyManagementSystem.Api.Core.Model
{
    using PolicyManagementSystem.Api.Core.Enums;
    using System.ComponentModel.DataAnnotations;

    public class PolicyModel
    {

        [EnumDataType(typeof(Title))]
        [Required(ErrorMessage = "Please enter the title")]
        public Title Title { get; set; }

        [Required(ErrorMessage = "Please enter the first name")]
        [StringLength(25, ErrorMessage = "Maximum characters exceed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the sur name")]
        [StringLength(25, ErrorMessage = "Maximum characters exceed")]
        public string SurName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }
        
        [Required (ErrorMessage = "Please enter the postcode")]
        public string Postcode { get; set; }

        [EnumDataType(typeof(ProductType))]
        [Required(ErrorMessage = "Please enter the product type")]
        public ProductType ProductType { get; set; }

        [EnumDataType(typeof(CoverType))]
        [Required(ErrorMessage = "Please enter the cover type")]
        public CoverType CoverType { get; set; }
       
        public decimal SumAssured { get; set; }

        public decimal MonthlyPremium { get; set; }

        [EnumDataType(typeof(UWQuestionOptions))]
        [Required(ErrorMessage = "Please enter the smoker status")]
        public UWQuestionOptions CurrentSmoker { get; set; }

        [EnumDataType(typeof(UWQuestionOptions))]
        [Required(ErrorMessage = "Please enter the health status")]
        public UWQuestionOptions HealthIssues { get; set; }

    }
}
