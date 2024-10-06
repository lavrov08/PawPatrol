using PawPatrol.Domain.Abstractions;
using PawPatrol.Domain.Shared;

namespace PawPatrol.Domain.Specieses;

public sealed class Species: Entity
{
    //Ef core
    private Species()
    {
    }

    private Species(Guid id,Name name, IEnumerable<Breed> breeds)
        : base(id)
    {
        Name = name;
        _breeds = breeds.ToList();
    }

    public static Species Create(Name name, IEnumerable<Breed> breeds)
    {
        return new Species(Guid.NewGuid(), name, breeds);
    }
    public Name Name { get; private set; }
    
    private readonly List<Breed> _breeds;
    public IReadOnlyCollection<Breed> Breeds => _breeds.AsReadOnly();
}