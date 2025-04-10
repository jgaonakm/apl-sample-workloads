public partial class DummyAnimalStore : IAnimalStore
{
    private static IList<Animal> _animalData = new List<Animal>();
    public Task<IEnumerable<Animal>> GetAll()
    {
        return Task.FromResult(_animalData.AsEnumerable());
    }

    public Task<IEnumerable<Animal>> GetFirstN(int n)
    {
        return Task.FromResult(_animalData.Take(n));
    }
}