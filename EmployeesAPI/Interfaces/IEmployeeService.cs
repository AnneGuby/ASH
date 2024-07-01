using EmployeesAPI.Domains;

namespace EmployeesAPI.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<string> AddEmployee(Employee employee);
    }
}
