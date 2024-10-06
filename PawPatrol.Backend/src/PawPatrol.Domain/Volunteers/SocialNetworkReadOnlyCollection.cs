using System.Collections.ObjectModel;

namespace PawPatrol.Domain.Volunteers;

public record SocialNetworkReadOnlyCollection
{
    public List<SocialNetwork> SocialNetworks { get; private set; }
}