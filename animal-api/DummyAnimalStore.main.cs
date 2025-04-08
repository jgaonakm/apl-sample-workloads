
using System.Linq;

public partial class DummyAnimalStore : IAnimalStore
{
    private static IList<Animal> _animalData = new List<Animal>();
    public IEnumerable<Animal> GetAll()
    {
        return _animalData.AsEnumerable();
    }

    public IEnumerable<Animal> GetFirstN(int n)
    {
        return _animalData.Take(n);
    }
}