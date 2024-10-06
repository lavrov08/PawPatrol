using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPatrol.Domain.Pets;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Infrastructure.Configurations;

public class PetConfiguration: IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets", "public");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Name)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                name => name.Value, 
                value => new Name(value)
            );
        
        builder.Property(v => v.Kind)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                kind => kind.Value,
                value => new Kind(value)
            );
        
        builder.Property(v => v.Description)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGHT)
            .HasConversion(
                description => description.Value,
                value => new Description(value)
            );
        
        builder.OwnsOne(v => v.Breed, navigationBuilder =>
        {
            navigationBuilder.Property(v => v.Value);
        });
        
        
        builder.Property(v => v.Color)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                color => color.Value,
                value => new Color(value)
            );
        
        builder.Property(v => v.HealthInfo)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                healthInfo => healthInfo.Value,
                value => new HealthInfo(value)
            );
        
        builder.Property(v => v.Address)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                address => address.Value,
                value => new Adress(value)
            );

        builder.Property(v => v.Weight);
        builder.Property(v => v.Height);
        
        builder.Property(v => v.PhoneNumber)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                phoneNumber => phoneNumber.Value,
                value => new PhoneNumber(value)
            );
        
        builder.Property(v => v.IsCastrated);
        
        builder.Property(v => v.IsVaccinated);
        
        builder.Property(v => v.BirthDate);
        
        
        builder.Property(v => v.PetStatus)
            .HasConversion(
                petStatus => petStatus.ToString(),
                value => Enum.Parse<PetStatus>(value)
            );
        
        builder.OwnsOne(v => v.Requisites, navigationBuilder =>
        {
            navigationBuilder.ToJson();
            
            navigationBuilder.OwnsMany(r => r.Requisites, requisiteBuilder =>
            {
                requisiteBuilder
                    .Property(r => r.RequisiteType)
                    .HasConversion(
                        type => type.ToString(), 
                        value => Enum.Parse<RequisiteType>(value)
                        );
                
                requisiteBuilder.Property(r => r.Value);
            });

        });
        
        builder.OwnsOne(v => v.PetPhotos, navigationBuilder =>
        {
            navigationBuilder.ToJson();
            
            navigationBuilder.OwnsMany(r => r.PetPhotos, petPhotoBuilder =>
            {
                petPhotoBuilder.Property(r => r.Path);
                
                petPhotoBuilder.Property(r => r.IsMain);
            });

        });
    }
}