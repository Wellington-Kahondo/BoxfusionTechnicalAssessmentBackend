using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Uow;
using Abp.ObjectMapping;
using Abp.Runtime.Validation;
using Abp.UI;
using Boxfusion.TechnicalAssessment.Domain.Addresses;
using Boxfusion.TechnicalAssessment.Domain.Employees;
using Boxfusion.TechnicalAssessment.Domain.Skills;
using Boxfusion.TechnicalAssessment.Services.Employees.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Boxfusion.TechnicalAssessment.Services.Employees
{
    public class EmployeeAppService : IApplicationService
    {
        private readonly EmployeeManager _employeeManager;
        private readonly AddressManager _addressManager;
        private readonly SkillManager _skillManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IObjectMapper _objectMapper;
        public EmployeeAppService(EmployeeManager employeeManager,
                                  AddressManager addressManager,
                                  SkillManager skillManager,
                                  IUnitOfWorkManager unitOfWorkManager,
                                  IObjectMapper objectMapper)
        {
            _employeeManager = employeeManager;
            _unitOfWorkManager = unitOfWorkManager;
            _objectMapper = objectMapper;
            _addressManager = addressManager;
            _skillManager = skillManager;
        }

        [HttpPost]
        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto input)
        {
            var employee = Employee.CreateNewEmployee();
            employee = _objectMapper.Map(input, employee);

            var validator = new EmployeeValidator();
            var results = validator.Validate(employee);

            var validationResults = new List<ValidationResult>();

            if (!results.IsValid)
            {

                foreach (var error in results.Errors)
                {
                    validationResults.Add(new ValidationResult(error.ErrorMessage, new[] { error.PropertyName }));
                }
            }

            if (validationResults.Any())
                throw new AbpValidationException("Failed to save the data", validationResults);

            using (var uow = _unitOfWorkManager.Begin())
            {
                if (input.Address != null)
                {
                    var address = _objectMapper.Map<Address>(input.Address);

                    employee.Address = await _addressManager.CreateAddressAsync(address);
                }

                employee = await _employeeManager.CreateEmployeeAsync(employee);

                await uow.CompleteAsync();
            }

            var updatedEmployee = await _employeeManager.GetEmployeeAsync(employee.Id);
            return _objectMapper.Map<EmployeeDto>(updatedEmployee);
        }

        [HttpPut]
        public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto input)
        {
            var employee = await _employeeManager.GetEmployeeAsync(input.Id);

            if (employee == null)
                throw new UserFriendlyException("Employee not found");

            var address = employee.Address;
            var skills = employee.Skills;

            _objectMapper.Map(input, employee);

            using (var uow = _unitOfWorkManager.Begin())
            {
                //Create a new address if the address is not null and the employee does not have an address
                if (address == null && input.Address != null)
                {
                    address = _objectMapper.Map<Address>(input.Address);
                    employee.Address = await _addressManager.CreateAddressAsync(address);

                }
                else
                {
                    // Update the address
                    _objectMapper.Map(input.Address, address);

                    await _addressManager.UpdateAddressAsync(address);
                }

                // Update employee
                await _employeeManager.UpdateEmployeeAsync(employee);

                //Update skills
                if (!input.Skills.IsNullOrEmpty())
                {
                    foreach (var skill in input.Skills)
                    {

                        if (skill.Id == Guid.Empty)
                        {
                            var newSkill = _objectMapper.Map<Skill>(skill);
                            newSkill.Employee = employee;

                            await _skillManager.CreateSkillAsync(newSkill);
                        }
                    }
                }


                //Delete skills
                if (!employee.Skills.IsNullOrEmpty())
                {
                    foreach (var skill in skills)
                    {
                        if (!input.Skills.Any(x => x.Id == skill.Id))
                        {
                            await _skillManager.DeleteSkillAsync(skill.Id);
                        }
                    }
                }

                await uow.CompleteAsync();
            }

            return _objectMapper.Map<EmployeeDto>(employee);

        }

        [HttpGet]
        public async Task<EmployeeDto> GetEmployeeAsync(string id)
        {
            var employee = await _employeeManager.GetEmployeeAsync(id);

            if (employee == null)
                throw new UserFriendlyException("Employee not found");

            return _objectMapper.Map<EmployeeDto>(employee);
        }


        [HttpGet]
        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeManager.GetAllEmployeesAsync();

            return _objectMapper.Map<List<EmployeeDto>>(employees);
        }

        [HttpPost]
        public async Task DeleteEmployee(string id)
        {

            var employee = await _employeeManager.GetEmployeeAsync(id);

            if (employee == null)
                throw new UserFriendlyException("Employee not found");

            if (!employee.Skills.IsNullOrEmpty())
            {
                foreach (var skill in employee.Skills)
                {
                    await _skillManager.DeleteSkillAsync(skill.Id);
                }
            }
            await _employeeManager.DeleteEmployeeAsync(id);

        }

    }
}
