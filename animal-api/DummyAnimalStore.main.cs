public partial class DummyAnimalStore : IAnimalStore
{
    private static IList<Animal> _animalData = new List<Animal>();

    public Task Create(Animal animal)
    {
        _animalData.Add(animal);
        return Task.CompletedTask;
    }

    public Task Delete(Animal animal)
    {
        _animalData.Remove(animal);
        return Task.CompletedTask;
    }

    public Task<Animal?> Get(int id)
    {
        return Task.FromResult(_animalData.FirstOrDefault(a => a.Id == id));
    }

    public Task<IEnumerable<Animal>> GetAll()
    {
        return Task.FromResult(_animalData.AsEnumerable());
    }

    public Task<IEnumerable<Animal>> GetFirstN(int n)
    {
        return Task.FromResult(_animalData.Take(n));
    }
}