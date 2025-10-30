using Coffee.Models;
using Coffee.Models.DTOs;
using Coffee.Repositories;

namespace Coffee.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
    {
        _employeeRepository = employeeRepository;
        _logger = logger;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest request)
    {
        var existing = await _employeeRepository.GetByEmployeeCodeAsync(request.EmployeeCode);
        if (existing != null)
        {
            throw new InvalidOperationException($"Employee with code {request.EmployeeCode} already exists");
        }

        var employee = new Employee
        {
            EmployeeCode = request.EmployeeCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Department = request.Department,
            Position = request.Position,
            Salary = request.Salary,
            JoinDate = DateTime.UtcNow,
            Status = "Active"
        };

        await _employeeRepository.AddAsync(employee);
        _logger.LogInformation($"Created new employee with code {employee.EmployeeCode}");

        return ToDto(employee);
    }

    public async Task<EmployeeDto?> GetEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return employee != null ? ToDto(employee) : null;
    }

    public async Task<EmployeeDto?> GetEmployeeByCodeAsync(string code)
    {
        var employee = await _employeeRepository.GetByEmployeeCodeAsync(code);
        return employee != null ? ToDto(employee) : null;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Select(ToDto);
    }

    public async Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync()
    {
        var employees = await _employeeRepository.GetActiveEmployeesAsync();
        return employees.Select(ToDto);
    }

    public async Task UpdateEmployeeAsync(int id, UpdateEmployeeRequest request)
    {
        var employee = await _employeeRepository.GetByIdAsync(id) 
            ?? throw new InvalidOperationException($"Employee with ID {id} not found");

        employee.PhoneNumber = request.PhoneNumber;
        employee.Address = request.Address;
        employee.Department = request.Department;
        employee.Position = request.Position;
        employee.Salary = request.Salary;
        employee.Status = request.Status;

        if (request.Status == "Terminated" && employee.TerminationDate == null)
        {
            employee.TerminationDate = DateTime.UtcNow;
        }

        await _employeeRepository.UpdateAsync(employee);
        _logger.LogInformation($"Updated employee {employee.EmployeeCode}");
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee != null)
        {
            await _employeeRepository.DeleteAsync(id);
            _logger.LogInformation($"Deleted employee {employee.EmployeeCode}");
        }
    }

    private static EmployeeDto ToDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            EmployeeCode = employee.EmployeeCode,
            FullName = $"{employee.FirstName} {employee.LastName}",
            PhoneNumber = employee.PhoneNumber,
            Department = employee.Department ?? "N/A",
            Position = employee.Position ?? "N/A",
            Status = employee.Status
        };
    }
}