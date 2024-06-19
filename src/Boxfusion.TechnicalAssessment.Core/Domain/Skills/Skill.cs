using Abp.Domain.Entities.Auditing;
using Boxfusion.TechnicalAssessment.Domain.Employees;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.TechnicalAssessment.Domain.Skills
{
    public class Skill : AuditedEntity<Guid>
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
        /// 
        public virtual string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        
    }
}
