using PawPatrol.Domain.Abstractions;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Domain.Specieses;

public sealed class Breed : Entity
{
    //Ef core
    private Breed()
    {
    }
    
    private Breed(Guid id,Name name)
        : base(id)
    {
        Name = name;
    }
    
    public static Breed Create(Name name)
    {
        return new Breed(Guid.NewGuid(), name);
    }
    
    public Name Name { get; private set; }
}