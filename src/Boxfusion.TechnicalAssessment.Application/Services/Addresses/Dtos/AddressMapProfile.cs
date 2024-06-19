using AutoMapper;
using Boxfusion.TechnicalAssessment.Domain.Addresses;

namespace Boxfusion.TechnicalAssessment.Services.Addresses.Dtos
{
    public class AddressMapProfile : Profile
    {
        public AddressMapProfile()
        {
              CreateMap<AddressDto, Address>()
                .ForMember(x => x.Id, opt => opt.Ignore()); 
        }
    }
}
