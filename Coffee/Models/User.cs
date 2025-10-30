using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee.Models;

[Table("User")]
public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(256)]
    public string Email { get; set; } = null!;

    // Store hashed password only. Never store plain text.
    [Required]
    [MaxLength(512)]
    public string PasswordHash { get; set; } = null!;

    // Optional salt field if you use per-user salts (otherwise salt may be embedded in PasswordHash)
    [MaxLength(128)]
    public string? PasswordSalt { get; set; }

    [MaxLength(50)]
    public string? Role { get; set; } = "User";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}