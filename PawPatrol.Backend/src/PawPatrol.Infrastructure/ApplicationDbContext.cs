using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PawPatrol.Domain.Pets;
using PawPatrol.Domain.Specieses;
using PawPatrol.Domain.Volunteers;

namespace PawPatrol.Infrastructure;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private const string DATABASE_POSTGRES = "postgres";
    
    public DbSet<Volunteer> Volunteers => Set<Volunteer>();
    
    public DbSet<Pet> Pets => Set<Pet>();
    
    public DbSet<Species> Species => Set<Species>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = 
            configuration.GetConnectionString(DATABASE_POSTGRES)??
            throw new ArgumentNullException(nameof(configuration));
        
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole();
        });
    }
    
}