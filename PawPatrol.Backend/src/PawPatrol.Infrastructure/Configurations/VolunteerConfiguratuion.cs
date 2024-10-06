using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawPatrol.Domain.Volunteers;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Infrastructure.Configurations;

internal sealed class VolunteerConfiguratuion: IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers", "public");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Name)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                name => name.Value, 
                value => new Name(value)
                );
        
        builder.Property(v => v.Email)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                email => email.Value,
                value => new Email(value)
            );
        
        builder.Property(v => v.PhoneNumber)
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGHT)
            .HasConversion(
                phoneNumber => phoneNumber.Value,
                value => new PhoneNumber(value)
            );
        
        builder.Property(v => v.Description)
            .HasMaxLength(Constants.MAX_HIGHT_TEXT_LENGHT)
            .HasConversion(
                description => description.Value,
                value => new Description(value)
            );
        
        builder.Property(v => v.Experience);

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
        
        builder.OwnsOne(v => v.SocialNetworks, navigationBuilder  =>
        {
            navigationBuilder.ToJson();
            
            navigationBuilder.OwnsMany(
                r => r.SocialNetworks, socialNetworkBuilder => 
                { 
                    socialNetworkBuilder.Property(r => r.Name); 
                    
                    socialNetworkBuilder
                        .Property(r => r.Url)
                        .HasConversion(
                            url => url.Value, 
                            value => new Url(value)
                            ); 
                }
                );
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}