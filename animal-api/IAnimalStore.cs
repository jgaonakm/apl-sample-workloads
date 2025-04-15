public interface IAnimalStore{

    Task<Animal?> Get(int id);
    Task<IEnumerable<Animal>> GetAll();

    Task<IEnumerable<Animal>> GetFirstN(int n);

    Task<IEnumerable<Animal>> GetByClass(string name);

    Task Create(Animal animal);

    Task Update(Animal animal);

    Task Delete(Animal animal);
}