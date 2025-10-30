using Coffee.Models;
using Coffee.Models.DTOs;

namespace Coffee.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest request);
    Task<EmployeeDto?> GetEmployeeAsync(int id);
    Task<EmployeeDto?> GetEmployeeByCodeAsync(string code);
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync();
    Task UpdateEmployeeAsync(int id, UpdateEmployeeRequest request);
    Task DeleteEmployeeAsync(int id);
}