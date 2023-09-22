using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(x => x.Freelancer)
            .WithMany(x => x.FreelancerProjects)
            .HasForeignKey(x => x.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.OwnedProjects)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}