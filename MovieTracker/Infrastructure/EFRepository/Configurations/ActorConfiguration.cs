using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFRepository.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasCheckConstraint(
            "CK_Actor_Year",
            "Year >= 1800 AND Year <= 2020");
        
        builder.Property(a => a.Name)
            .HasMaxLength(30)
            .IsRequired();
    }
}