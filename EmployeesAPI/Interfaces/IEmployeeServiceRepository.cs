using EmployeesAPI.Domains;

namespace EmployeesAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<string> AddEmployee(Employee employee);
    }
}
