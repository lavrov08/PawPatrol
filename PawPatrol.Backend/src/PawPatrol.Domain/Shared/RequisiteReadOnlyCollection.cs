using System.Collections.ObjectModel;

namespace PawPatrol.Domain.Shared;

public record RequisiteReadOnlyCollection
{
    public List<Requisite> Requisites { get; private set; }
}