using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFRepository.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies").Property(m => m.Rating)
                                 .IsRequired(false);
        
        builder.Property(a => a.Title)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.HasCheckConstraint(
            "CK_Movie_DurationMinutes",
            "\"DurationMinutes\" > 0 AND \"DurationMinutes\" < 6000");

        builder.HasCheckConstraint(
            "CK_Movie_Rating",
            "\"Rating\" IS NULL OR (\"Rating\" >= 1 AND \"Rating\" <= 10)");

        builder.HasCheckConstraint(
            "CK_Movie_Year",
            "\"Year\" >= 1800 AND \"Year\" <= 2026");
    }
}