using Microsoft.AspNetCore.Mvc;

[Route("/animals")]
public class AnimalController : ControllerBase
{
    IAnimalStore _animalStore;
    public AnimalController(IAnimalStore animalStore)
    {
        _animalStore = animalStore;
    }


    [HttpGet("")]
    public ActionResult GetAll()
    {
        Console.WriteLine("Getting all animals. It could take a while");
        var animals = _animalStore.GetAll();
        return Ok(animals);
    }

    [HttpGet("{size:int}")]
    public ActionResult GetFirstN(int size)
    {
        Console.WriteLine($"Getting first {size} animals.");
        var animals = _animalStore.GetFirstN(size);
        return Ok(animals);
    }

    // [HttpPost("/populate")]
    // public ActionResult Populate()
    // {
    //     Console.WriteLine("Resetting the animals list");
    //     _animalStore.Populate();

    //     return Ok();
    // }

}