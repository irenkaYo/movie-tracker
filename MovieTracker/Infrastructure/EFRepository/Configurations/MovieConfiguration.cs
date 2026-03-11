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
        
        builder.HasCheckConstraint(
            "CK_Movie_Rating",
            "Rating IS NULL OR (Rating >= 1 AND Rating <= 10)");
        
        builder.HasCheckConstraint(
            "CK_Movie_Year",
            "Year >= 1000 AND Year <= 2000");
        
        builder.HasCheckConstraint(
            "CK_Movie_Duration",
            "DurationMinutes > 0");
    }
}