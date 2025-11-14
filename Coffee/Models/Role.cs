using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee.Models;

[Table("Role")]
public class Role
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    [MaxLength(100)]
    public string RoleName { get; set; } = null!;

    [MaxLength(200)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public bool IsSystem { get; set; } = false;
}
