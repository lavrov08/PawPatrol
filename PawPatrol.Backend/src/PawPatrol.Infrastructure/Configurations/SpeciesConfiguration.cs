using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPatrol.Domain.Shared;
using PawPatrol.Domain.Specieses;

namespace PawPatrol.Infrastructure.Configurations;

public class SpeciesConfiguration: IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species", "public");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Name)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                name => name.Value, 
                value => new Name(value)
            );
        
        builder.HasMany(v => v.Breeds)
            .WithOne()
            .HasForeignKey("species_id)");

    }
}