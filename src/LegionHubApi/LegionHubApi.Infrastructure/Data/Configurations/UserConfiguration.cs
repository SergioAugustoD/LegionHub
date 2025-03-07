using System;
using LegionHubApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegionHubApi.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Password).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Role).IsRequired().HasMaxLength(20);
            builder.Property(u => u.CreatedAt).IsRequired();
        }
}
