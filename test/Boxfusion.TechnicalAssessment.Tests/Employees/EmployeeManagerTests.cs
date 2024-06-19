using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using Abp.Domain.Repositories;
using MockQueryable.Moq;

namespace Boxfusion.TechnicalAssessment.Domain.Employees.Tests
{
    public class EmployeeManagerTests
    {
        private readonly Mock<IRepository<Employee, string>> _mockRepository;
        private readonly Mock<IEmployeeIdGenerator> _mockIdGenerator;
        private readonly EmployeeManager _employeeManager;

        public EmployeeManagerTests()
        {
            _mockRepository = new Mock<IRepository<Employee, string>>();
            _mockIdGenerator = new Mock<IEmployeeIdGenerator>();
            _employeeManager = new EmployeeManager(_mockRepository.Object);

            // Mock the ID generator
            _mockIdGenerator.Setup(g => g.GenerateNewId()).Returns("1");
        }

        private Employee CreateEmployee()
        {
            // Create a new employee using reflection
            var employee = (Employee)Activator.CreateInstance(typeof(Employee), true);
            employee.Id = _mockIdGenerator.Object.GenerateNewId();
            employee.FirstName = "John";
            employee.LastName = "Doe";
            return employee;
        }

        [Fact]
        public async Task CreateEmployeeAsync_ShouldReturnCreatedEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            _mockRepository.Setup(r => r.InsertAsync(It.IsAny<Employee>())).ReturnsAsync(employee);

            // Act
            var result = await _employeeManager.CreateEmployeeAsync(employee);

            // Assert
            result.ShouldBe(employee);
            _mockRepository.Verify(r => r.InsertAsync(employee), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeAsync_ShouldReturnEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            var employees = new List<Employee> { employee }.AsQueryable().BuildMockDbSet();

            _mockRepository.Setup(r => r.GetAllIncluding(It.IsAny<Expression<Func<Employee, object>>[]>()))
                           .Returns(employees.Object);

            // Act
            var result = await _employeeManager.GetEmployeeAsync(employee.Id);

            // Assert
            result.ShouldBe(employee);
            _mockRepository.Verify(r => r.GetAllIncluding(It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ShouldReturnListOfEmployees()
        {
            // Arrange
            var employee1 = CreateEmployee();
            var employee2 = CreateEmployee();
            employee2.Id = "2";  // Ensure different IDs for employees
            var employees = new List<Employee> { employee1, employee2 }.AsQueryable().BuildMockDbSet();

            _mockRepository.Setup(r => r.GetAllIncluding(It.IsAny<Expression<Func<Employee, object>>[]>()))
                           .Returns(employees.Object);

            // Act
            var result = await _employeeManager.GetAllEmployeesAsync();

            // Assert
            result.ShouldBe(employees.Object.ToList());
            _mockRepository.Verify(r => r.GetAllIncluding(It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_ShouldReturnUpdatedEmployee()
        {
            // Arrange
            var employee = CreateEmployee();
            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Employee>())).ReturnsAsync(employee);

            // Act
            var result = await _employeeManager.UpdateEmployeeAsync(employee);

            // Assert
            result.ShouldBe(employee);
            _mockRepository.Verify(r => r.UpdateAsync(employee), Times.Once);
        }

        [Fact]
        public async Task DeleteEmployeeAsync_ShouldCallDeleteAsync()
        {
            // Arrange
            var employeeId = "1";
            _mockRepository.Setup(r => r.DeleteAsync(employeeId)).Returns(Task.CompletedTask);

            // Act
            await _employeeManager.DeleteEmployeeAsync(employeeId);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(employeeId), Times.Once);
        }
    }

    // Mocked interface for EmployeeIdGenerator
    public interface IEmployeeIdGenerator
    {
        string GenerateNewId();
    }
}
