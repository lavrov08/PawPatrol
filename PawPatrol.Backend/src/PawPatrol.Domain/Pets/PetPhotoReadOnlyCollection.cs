using System.Collections.ObjectModel;

namespace PawPatrol.Domain.Pets;

public record PetPhotoReadOnlyCollection
{
    public List<PetPhoto> PetPhotos { get; private set; }
}