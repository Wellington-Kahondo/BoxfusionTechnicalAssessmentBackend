using AutoMapper;
using Boxfusion.TechnicalAssessment.Domain.Employees;
using Boxfusion.TechnicalAssessment.Services.Employees.Dtos;

namespace Boxfusion.TechnicalAssessment.Services.Employees
{
    public class EmployeeMapProfile : Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Address, opt => opt.Ignore());

            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(x => x.Skills, opt => opt.MapFrom(x => x.Skills));
        }
    }
}
