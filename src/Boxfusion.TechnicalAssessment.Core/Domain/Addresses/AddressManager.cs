using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Boxfusion.TechnicalAssessment.Domain.Addresses
{
    public class AddressManager : DomainService
    {
        private readonly IRepository<Address, Guid> _addressRepository;
        public AddressManager(IRepository<Address, Guid> addressRepository) 
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            address = await _addressRepository.InsertAsync(address);

            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            var test = await _addressRepository.UpdateAsync(address); 
            
            return test;
        }
    }
}
