using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegionHubApi.Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("username")]
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Column("email")]
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Column("password")]
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [Column("role")]
    [Required]
    [MaxLength(20)]
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
