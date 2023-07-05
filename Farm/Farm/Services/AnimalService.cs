using Farm.Services.Contracts;

namespace Farm.Services;

public class AnimalService : IAnimalService
{
    private HashSet<string> _animals = new(StringComparer.CurrentCultureIgnoreCase);

    public bool Add(string name)
    {
        return _animals.Add(name);
    }

    public bool Delete(string name)
    {
        return _animals.Remove(name);
    }

    public ICollection<string> GetAnimals()
    {
        return _animals;
    }
}
