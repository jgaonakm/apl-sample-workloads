public interface IAnimalStore{
    Task<IEnumerable<Animal>> GetAll();

    Task<IEnumerable<Animal>> GetFirstN(int n);

}