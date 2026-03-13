using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFRepository.Configurations;

public class GenreConfiguration :  IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(a => a.Name)
            .HasMaxLength(30)
            .IsRequired();
    }
}