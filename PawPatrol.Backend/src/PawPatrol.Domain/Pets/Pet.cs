using PawPatrol.Domain.Abstractions;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Domain.Pets;

public sealed class Pet : Entity
{
    private Pet(Guid id,
        Name name,
        Kind kind,
        Description description,
        Breed breed,
        Color color,
        HealthInfo healthInfo,
        Adress address,
        double weight,
        double height,
        PhoneNumber phoneNumber,
        bool isCastrated,
        bool isVaccinated,
        DateTime birthDate,
        PetStatus petStatus,
        IEnumerable<Requisite> requisites,
        IEnumerable<PetPhoto> petPhotos
        ) : base(id)
    {
        Name = name;
        Kind = kind;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phoneNumber;
        IsCastrated = isCastrated;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        PetStatus = petStatus;
        _requisites = requisites.ToList();
        _petPhotos = petPhotos.ToList();
    }

    /// <summary>
    /// Creates a new <see cref="Pet"/> instance.
    /// </summary>
    /// <param name="name">The name of the pet.</param>
    /// <param name="kind">The kind of the pet.</param>
    /// <param name="description">A description of the pet.</param>
    /// <param name="breed">The breed of the pet.</param>
    /// <param name="color">The color of the pet.</param>
    /// <param name="healthInfo">The health information of the pet.</param>
    /// <param name="address">The address of the pet.</param>
    /// <param name="weight">The weight of the pet.</param>
    /// <param name="height">The height of the pet.</param>
    /// <param name="phoneNumber">The phone number of the pet.</param>
    /// <param name="isCastrated">Whether the pet is castrated.</param>
    /// <param name="isVaccinated">Whether the pet is vaccinated.</param>
    /// <param name="birthDate">The birth date of the pet.</param>
    /// <param name="petStatus">The status of the pet.</param>
    /// <param name="requisites">The collection of requisites of the pet.</param>
    /// <param name="petPhotos">The collection of photos of the pet.</param>
    /// <returns>A new <see cref="Pet"/> instance.</returns>
    public static Pet Create(
        Name name,
        Kind kind, 
        Description description, 
        Breed breed, Color color,
        HealthInfo healthInfo,
        Adress address,
        double weight,
        double height,
        PhoneNumber phoneNumber,
        bool isCastrated,
        bool isVaccinated,
        DateTime birthDate,
        PetStatus petStatus,
        IEnumerable<Requisite> requisites,
        IEnumerable<PetPhoto> petPhotos)
    {
        var pet = new Pet(
            Guid.NewGuid(), 
            name, 
            kind, 
            description,
            breed,
            color,
            healthInfo,
            address, 
            weight, 
            height, 
            phoneNumber,
            isCastrated, 
            isVaccinated, 
            birthDate, 
            petStatus, 
            requisites,
            petPhotos);
        
        return pet;
    }

    public Name Name { get; private set; }
    
    public Kind Kind { get; private set; }
    
    public Description Description { get; private set; }
    
    public Breed Breed { get; private set; }
    
    public Color Color { get; private set; }
    
    public HealthInfo HealthInfo { get; private set; }
    
    public Adress Address { get; private set; }
    
    public double Weight { get; private set; }
    
    public double Height { get; private set; }
    
    public PhoneNumber PhoneNumber { get; private set; }
    
    public bool IsCastrated { get; private set; }
    
    public bool IsVaccinated { get; private set; }
    
    public DateTime BirthDate { get; private set; }
    
    public PetStatus PetStatus { get; private set; }
    
    private readonly List<Requisite> _requisites;
    
    public IReadOnlyCollection<Requisite> Requisites => _requisites.AsReadOnly();
    
    private readonly List<PetPhoto> _petPhotos;

    public IReadOnlyList<PetPhoto> PetPhotos => _petPhotos.AsReadOnly();

    public DateTime DateCreated { get; private set; } = DateTime.Now;
}