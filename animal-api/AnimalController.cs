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
    public async Task<ActionResult> GetAll()
    {
        Console.WriteLine("Getting all animals. It could take a while");
        var animals = await _animalStore.GetAll();
        return Ok(animals);
    }

    [HttpGet("{size:int}")]
    [Produces("application/xml")]
    public async Task<ActionResult> GetFirstN(int size)
    {
        Console.WriteLine($"Getting first {size} animals.");
        var values = await _animalStore.GetFirstN(size);
        var animals = new Animals(values.ToList());
        return Ok(animals);
    }
}