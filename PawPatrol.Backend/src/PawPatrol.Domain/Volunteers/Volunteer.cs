using PawPatrol.Domain.Abstractions;
using PawPatrol.Domain.Pets;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Domain.Volunteers;

public sealed class Volunteer:Entity
{ 
    public Name Name { get; private set; }
    
    public Email Email { get; private set; }
    
    public PhoneNumber PhoneNumber { get; private set; }
    
    public Description Description { get; private set; }
    
    public int Experience { get; private set; }
    
    public SocialNetworkReadOnlyCollection SocialNetworks { get; private set; }
    
    public RequisiteReadOnlyCollection Requisites { get; private set; }
    
    private readonly List<Pet> _pets;
    
    public IReadOnlyCollection<Pet> Pets => _pets.AsReadOnly();
    
    public int PetsFoundHomeCount() => _pets.Count(pet => pet.PetStatus == PetStatus.FoundHome);
    
    public int PetsSeekingHomeCount() => _pets.Count(pet=> pet.PetStatus == PetStatus.SeeksHome);
    
    public int PetsOnTreatmentCount() => _pets.Count(pet=> pet.PetStatus == PetStatus.OnTreatment);

    private Volunteer(
        Guid id,
        Name name,
        Email email,
        PhoneNumber phoneNumber,
        Description description,
        int experience,
        SocialNetworkReadOnlyCollection socialNetworks,
        RequisiteReadOnlyCollection requisites,
        List<Pet> pets) 
        : base(id)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Description = description;
        Experience = experience;
        SocialNetworks = socialNetworks;
        Requisites = requisites;
        _pets = pets;
    }

    public static Volunteer Create(
        Name name,
        Email email,
        PhoneNumber phoneNumber,
        Description description,
        int experience,
        SocialNetworkReadOnlyCollection socialNetworks,
        RequisiteReadOnlyCollection requisites,
        List<Pet> pets)
    {
        var volunteer = new Volunteer(
            Guid.NewGuid(),
            name, 
            email,
            phoneNumber, 
            description, 
            experience,
            socialNetworks,
            requisites, 
            pets);
        
        return volunteer;
    }
    
    //ef core 
    private Volunteer(){ }
}