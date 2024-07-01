using AutoFixture.Xunit2;
using EmployeesAPI.Domains;
using EmployeesAPI.Interfaces;
using EmployeesAPI.Repositories;
using Moq;
using Xunit;

namespace EmployeesAPI.Integration_Tests
{
    public class EmployeeTests
    {
     //   public object Assert { get; private set; }

        [Theory, AutoMoqData]
        public async Task GetEmployees_Test([Frozen] Mock<IEmployeeRepository> mockEmployeeRepository)
        {
            var employeeRepository = new EmployeeRepository();

            var employees = new List<Employee>() { new Employee { LastName= "Smith", FirstName= "Anne", EmployeeTypeId = 1} };
             
            mockEmployeeRepository.Setup(x => x.GetEmployees()).Returns(Task.FromResult(employees));
            var results = await employeeRepository.GetEmployees();
            Assert.Equal(results, employees);
        }

        [Theory, AutoMoqData]
        public async Task AddNewEmployee_Test([Frozen] Mock<IEmployeeRepository> mockEmployeeRepository)
        {
            var employeeRepository = new EmployeeRepository();

            var adjustments = new Employee
            {
                 FirstName =  "Anne",
                 LastName = "Smith", 
                 EmployeeTypeId = 1,
            };
            //arrange
            mockEmployeeRepository.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns(Task.FromResult(string.Empty));
            var results = await employeeRepository.AddEmployee(adjustments);
            Assert.Empty(results); 
        }

    }
}
