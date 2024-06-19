using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Boxfusion.TechnicalAssessment.Domain.Addresses
{
    public class Address : AuditedEntity<Guid>
    {
        [MaxLength(1000)]
        public virtual string Street { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string PostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Country { get; set; }
    }
}
