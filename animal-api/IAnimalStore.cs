public interface IAnimalStore{

    Task<Animal?> Get(int id);
    Task<IEnumerable<Animal>> GetAll();

    Task<IEnumerable<Animal>> GetFirstN(int n);

    Task Create(Animal animal);

    Task Delete(Animal animal);
}