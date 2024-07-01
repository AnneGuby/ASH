using EmployeesAPI.Data;
using EmployeesAPI.Domains;
using EmployeesAPI.Interfaces;
using System.Data.Entity;

namespace EmployeesAPI.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {

        public async Task<List<Employee>> GetEmployees()
        {
            Func<Entities, Task<List<Employee>>> query = async (context) =>
            {
                return await context.Employees.Include("EmployeeType").ToListAsync();
            };
            return await ExecuteSnapshotQueryAsync(query);             
        }

        public async Task<string> AddEmployee(Employee employee)
        {
            Func<Entities, Task<string>> query = async (context) =>
            {
                if (await context.Employees.AnyAsync(x => x.FirstName.Equals(employee.FirstName, StringComparison.InvariantCultureIgnoreCase)
                                                          || x.LastName.Equals(employee.LastName, StringComparison.InvariantCultureIgnoreCase)))
                    return $"{employee.FirstName} {employee.LastName} already exists";

                context.Employees.Add(employee);
                await context.SaveChangesAsync();
                return string.Empty;
            };

            var data = await ExecuteSnapshotQueryAsync(query);
            return data;
        }
    }
}
