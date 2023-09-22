using System.Reflection;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaContext : DbContext
{
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ProjectComment> ProjectComments { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<UserSkill> UsersSkills { get; set; } = null!;

    public DevFreelaContext(DbContextOptions<DevFreelaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}