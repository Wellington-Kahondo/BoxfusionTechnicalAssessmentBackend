using AutoMapper;
using Boxfusion.TechnicalAssessment.Domain.Skills;
using Boxfusion.TechnicalAssessment.Services.Helpers;

namespace Boxfusion.TechnicalAssessment.Services.Skills.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
             CreateMap<Skill, SkillDto>()
                .ForMember(x => x.SeniorityRatingText, opt => opt.MapFrom(e => e.SeniorityRating != null ? e.SeniorityRating.GetEnumDescription() : null));

        }
    }
}
