namespace PolicyManagementSystem.Api.Services
{
    using AutoMapper;
    using PolicyManagementSystem.Api.Core.Domain;
    using PolicyManagementSystem.Api.Core.Model;
    using System;

    public class AutoMapping : Profile
    {
         public AutoMapping()
        {
            CreateMap<Policy, PolicyModel>()
                .ForMember(d => d.CurrentSmoker, o => o.MapFrom(src => src.UnderwritingQuestions.CurrentSmoker))
                .ForMember(d => d.HealthIssues, o => o.MapFrom(src => src.UnderwritingQuestions.HealthIssues));
            CreateMap<PolicyModel, Policy>()
                .ForPath(d => d.UnderwritingQuestions.CurrentSmoker, o => o.MapFrom(src => src.CurrentSmoker))
                .ForPath(d => d.UnderwritingQuestions.HealthIssues, o => o.MapFrom(src => src.HealthIssues));
                //.AfterMap((s, d) => d.UnderwritingQuestions.CurrentSmoker = s.CurrentSmoker.ToString())
                //.AfterMap((s, d) => d.UnderwritingQuestions.HealthIssues = s.HealthIssues.ToString())
                //.BeforeMap((s, d) => d.CreatedBy = "admin")
                //.BeforeMap((s, d) => d.CreatedDate = DateTime.Now)
                //.BeforeMap((s, d) => d.Id = Guid.NewGuid().ToString())
                //.BeforeMap((s, d) => d.PolicyNumber = DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}
