using System.ComponentModel.DataAnnotations;

public class UserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FullName { get; set; } = null!;
}
public class UserCreateDto
{
    [Required]
    public string Username { get; set; }=null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }=null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    public string ConfirmPassword { get; set; } =null!;

    public int? EmployeeId { get; set; }     // liên kết với Employee

    public List<int> RoleIds { get; set; } = new List<int>();
}
public class UserUpdateDto
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string? Username { get; set; }

    public int? EmployeeId { get; set; }

    public bool IsActive { get; set; }

    public List<int> RoleIds { get; set; } = new List<int>();
}