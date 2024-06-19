using Abp.Domain.Entities.Auditing;
using Boxfusion.TechnicalAssessment.Domain.Addresses;
using Boxfusion.TechnicalAssessment.Domain.Skills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.TechnicalAssessment.Domain.Employees
{
    public class Employee : AuditedEntity<string>
    {
        public override string Id { get; set; }

        // Private parameterless constructor used by the ORM
        private Employee() { }

        // Static factory method to create new instances
        public static Employee CreateNewEmployee()
        {
            return new Employee
            {
                Id = EmployeeIdGenerator.GenerateNewId()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ContactNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Address Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[JsonIgnore]
        //[NotMapped]
        public virtual ICollection<Skill> Skills { get; set; }
       
    }
}
