using PawPatrol.Domain.Abstractions;
using PawPatrol.Domain.Pets;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Domain.Volunteers;

public class Volunteer:Entity
{ 
    public Name Name { get; private set; }
    
    public Email Email { get; private set; }
    
    public PhoneNumber PhoneNumber { get; private set; }
    
    public Description Description { get; private set; }
    
    public int Experience { get; private set; }
    
    public IReadOnlyCollection<SocialNetwork> SocialNetworks { get; private set; }
    
    public IReadOnlyCollection<Requisite> Requisites { get; private set; }
    
    public IReadOnlyCollection<Pet> Pets { get; private set; }
    
    public int PetsFoundHomeCount() => Pets.Count(pet => pet.PetStatus == PetStatus.FoundHome);
    
    public int PetsSeekingHomeCount() => Pets.Count(pet=> pet.PetStatus == PetStatus.SeeksHome);
    
    public int PetsOnTreatmentCount() => Pets.Count(pet=> pet.PetStatus == PetStatus.OnTreatment);

    private Volunteer(
        Guid id,
        Name name,
        Email email,
        PhoneNumber phoneNumber,
        Description description,
        int experience,
        List<SocialNetwork> socialNetworks,
        List<Requisite> requisites,
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
        Pets = pets; 
    }

    public static Volunteer Create(
        Name name,
        Email email,
        PhoneNumber phoneNumber,
        Description description,
        int experience,
        List<SocialNetwork> socialNetworks,
        List<Requisite> requisites,
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
}