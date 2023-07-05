namespace Farm.Services.Contracts;

public interface IAnimalService
{
    ICollection<string> GetAnimals();
    bool Delete(string name);
    bool Add(string name);
}
