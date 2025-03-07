using LegionHubApi.Domain.Entities;
using LegionHubApi.Infrastructure.Data.Configurations;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace LegionHubApi.Infrastructure.Data;

public class LegionHubContext : DbContext
{
    public LegionHubContext(DbContextOptions<LegionHubContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotEnv.Load();
        string? dataconfig = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
        optionsBuilder.UseNpgsql(dataconfig);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
