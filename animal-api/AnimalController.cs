using Microsoft.AspNetCore.Mvc;

[Route("/animals")]
[Produces("application/json", "application/xml")]
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
        var values = await _animalStore.GetAll();
        var animals = new Animals(values.ToList(), values.Count());
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetOne(int id)
    {
        Console.WriteLine("Getting animal with id {0}", id);
        var a = await _animalStore.Get(id);
        if (a is null) return NotFound();

        return Ok(a);
    }


    [HttpGet("subset/{size:int}")]
    public async Task<ActionResult> GetFirstN(int size)
    {
        Console.WriteLine($"Getting first {size} animals.");
        var values = await _animalStore.GetFirstN(size);
        var animals = new Animals(values.ToList(), values.Count());
        return Ok(animals);
    }

    [HttpPost("")]
    public async Task<ActionResult> Create([FromBody] Animal animal)
    {
        Console.WriteLine("Saving an animal");

        await _animalStore.Create(animal);

        return Created($"animals/{animal.Id}", animal);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        Console.WriteLine("Deleting animal with id {0}", id);
        var a = await _animalStore.Get(id);
        if (a is null) return NotFound();

        await _animalStore.Delete(a);
        return NoContent();
    }


}