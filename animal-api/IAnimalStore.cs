public interface IAnimalStore{
    IEnumerable<Animal> GetAll();

    IEnumerable<Animal> GetFirstN(int n);

    //void Populate();
}