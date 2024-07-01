using EmployeesAPI.Domains;
using EmployeesAPI.Interfaces;

namespace EmployeesAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository EmployeeRepository { get; }
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await EmployeeRepository.GetEmployees();
        }

        public async Task<string> AddEmployee(Employee employee)
        {
            return await EmployeeRepository.AddEmployee(employee);
        }
         
    }
}
