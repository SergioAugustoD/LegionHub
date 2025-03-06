using System;
using LegionHubApi.Domain.Entities;
using LegionHubApi.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LegionHubApi.Infra.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
    }

}
