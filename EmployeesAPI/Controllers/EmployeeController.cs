using EmployeesAPI.Domains;
using EmployeesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    [Route("[controller]/[action]/"), ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService EmployeeService { get; }
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            return await EmployeeService.GetEmployees();
        }
        [HttpPost]
        public async Task<string> AddEmployee(Employee employee)
        {
            return await EmployeeService.AddEmployee(employee);
        }
    }
}
