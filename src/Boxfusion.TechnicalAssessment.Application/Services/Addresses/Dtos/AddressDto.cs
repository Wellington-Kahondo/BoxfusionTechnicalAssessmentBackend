using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.TechnicalAssessment.Domain.Addresses;
using System;

namespace Boxfusion.TechnicalAssessment.Services.Addresses.Dtos
{
    [AutoMap(typeof(Address))]
    public class AddressDto : EntityDto<Guid>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
