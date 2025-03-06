using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegionHubApi.Domain.Entities;

[Table("user")]
public class User : BaseEntity
{
    [Column("user_name")]
    public string UserName { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("role")]
    public string Role { get; set; }

}
