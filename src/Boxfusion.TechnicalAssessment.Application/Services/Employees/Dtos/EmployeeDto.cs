using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.TechnicalAssessment.Domain.Employees;
using Boxfusion.TechnicalAssessment.Services.Addresses.Dtos;
using Boxfusion.TechnicalAssessment.Services.Skills.Dtos;
using System;
using System.Collections.Generic;


namespace Boxfusion.TechnicalAssessment.Services.Employees.Dtos
{
    [AutoMapTo(typeof(Employee))]
    public class EmployeeDto :EntityDto<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public AddressDto Address { get; set; }
        public IList<SkillDto> Skills { get; set; }
    }
}
