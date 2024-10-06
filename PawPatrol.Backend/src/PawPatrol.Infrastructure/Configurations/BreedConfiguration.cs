using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPatrol.Domain.Shared;
using PawPatrol.Domain.Specieses;

namespace PawPatrol.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds", "public");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Name)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                name => name.Value, 
                value => new Name(value)
            );
    }
}