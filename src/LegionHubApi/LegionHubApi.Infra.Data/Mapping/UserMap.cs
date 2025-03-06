using System;
using LegionHubApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegionHubApi.Infra.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);  

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("varchar(100)");    

    }

}
