using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.TechnicalAssessment.Domain.Skills;
using System;

namespace Boxfusion.TechnicalAssessment.Services.Skills.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Skill))]
    public class SkillDto : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int YearsExperience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListSeniorityRating? SeniorityRating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SeniorityRatingText { get; set; }
    }
}
