using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxfusion.TechnicalAssessment.Domain.Employees
{
    public class EmployeeManager : DomainService, IDomainService
    {
        private readonly IRepository<Employee, string> _employeeRepository;
        public EmployeeManager(IRepository<Employee, string> employeeRepository)
        {
            _employeeRepository = employeeRepository;    
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {

              return await _employeeRepository.InsertAsync(employee);

        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            var employee = await _employeeRepository.GetAllIncluding(x => x.Address, x => x.Skills)
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(x =>x.Id == id);

            return employee;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllIncluding(x => x.Address, x => x.Skills)
                                                     .ToListAsync();

            return employees;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.UpdateAsync(employee);
            
        }

        public async Task DeleteEmployeeAsync(string id)
        {

             await _employeeRepository.DeleteAsync(id);
            
        }

        public async Task<string> GenerateUniqueIdAsync()
        {
            string newId;
            bool idExists;

            do
            {
                newId = EmployeeIdGenerator.GenerateId();
                idExists = await _employeeRepository.GetAll().AnyAsync(e => e.Id == newId);
            } while (idExists);

            return newId;
        }


    }
}
