namespace Coffee.Models.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public string EmployeeCode { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Department { get; set; } = null!;
    public string Position { get; set; } = null!;
    public int StatusId { get; set; }
    public string Status { get; set; } = null!;
}

public class CreateEmployeeRequest
{
    public string EmployeeCode { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Department { get; set; }
    public string? Position { get; set; }
    public decimal Salary { get; set; }
}

public class UpdateEmployeeRequest
{
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Department { get; set; }
    public string? Position { get; set; }
    public decimal Salary { get; set; }
    public int StatusId { get; set; }
}