public partial class DummyAnimalStore : IAnimalStore
{
    private static IDictionary<int, Animal> _animalData = new Dictionary<int, Animal>();

    public Task Create(Animal animal)
    {
        _animalData.Add(animal.Id, animal);
        return Task.CompletedTask;
    }

    public Task Delete(Animal animal)
    {
        _animalData.Remove(animal.Id);
        return Task.CompletedTask;
    }

    public Task<Animal?> Get(int id)
    {
        Animal? animal;
        _animalData.TryGetValue(id, out animal);
        return Task.FromResult(animal);
    }

    public Task<IEnumerable<Animal>> GetAll()
    {
        return Task.FromResult(_animalData.Values.AsEnumerable());
    }

    public Task<IEnumerable<Animal>> GetByClass(string name)
    {
        return Task.FromResult(_animalData.Values.Where(a => a.ClassName.Equals(name, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<IEnumerable<Animal>> GetFirstN(int n)
    {
        return Task.FromResult(_animalData.Values.Take(n));
    }

    public Task Update(Animal animal)
    {
        _animalData[animal.Id] = animal;
        return Task.CompletedTask;
    }
}