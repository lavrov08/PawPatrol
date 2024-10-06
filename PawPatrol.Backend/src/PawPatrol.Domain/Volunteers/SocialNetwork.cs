using PawPatrol.Domain.Shared;

namespace PawPatrol.Domain.Volunteers;

public record SocialNetwork
{
    public string Name { get; private set; }
    public Url Url { get; private set; }
}