using Coffee.Data;
using Coffee.Models;
using Dapper;

namespace Coffee.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetByEmployeeCodeAsync(string code);
    Task<IEnumerable<Employee>> GetByDepartmentAsync(string department);
    Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
    Task<IEnumerable<EmployeeStatus>> GetEmployeeStatusesAsync();
    Task<IEnumerable<Employee>> GetAllEmployeeAsync();
}