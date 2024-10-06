using PawPatrol.Domain.Abstractions;
using PawPatrol.Domain.Shared;
using PawPatrol.Domain.Specieses;
using PawPatrol.Domain.Volunteers;

namespace PawPatrol.Domain.Pets;

public sealed class Pet : Entity
{
    //Ef Core
    private Pet(){}
    private Pet(Guid id,
        Name name,
        Kind kind,
        Description description,
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
        RequisiteReadOnlyCollection requisites,
        PetPhotoReadOnlyCollection petPhotos
        ) : base(id)
    {
        Name = name;
        Kind = kind;
        Description = description;
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
        Requisites = requisites;
        PetPhotos = petPhotos;
    }

    /// <summary>
    /// Creates a new <see cref="Pet"/> instance.
    /// </summary>
    /// <param name="name">The name of the pet.</param>
    /// <param name="kind">The kind of the pet.</param>
    /// <param name="description">A description of the pet.</param>
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
        RequisiteReadOnlyCollection requisites,
        PetPhotoReadOnlyCollection petPhotos)
    {
        var pet = new Pet(
            Guid.NewGuid(), 
            name, 
            kind, 
            description,
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
    
    public RequisiteReadOnlyCollection Requisites { get;private set; }

    public PetPhotoReadOnlyCollection PetPhotos { get;private set; }

    public DateTime DateCreated { get; private set; } = DateTime.Now;
}