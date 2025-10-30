using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee.Models;
[Table("Employee")]
public class Employee
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string EmployeeCode { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; set; } = null!;
    
    [Required]
    [MaxLength(200)]
    public string Address { get; set; } = null!;
    
    [Required]
    public DateTime JoinDate { get; set; }
    
    [MaxLength(50)]
    public string? Department { get; set; }
    
    [MaxLength(50)]
    public string? Position { get; set; }
    
    [Required]
    public decimal Salary { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Active";
    
    public DateTime? TerminationDate { get; set; }
}