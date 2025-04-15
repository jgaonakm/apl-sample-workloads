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


    [HttpGet("class/{group}")]
    public async Task<ActionResult> GetByClass(string group)
    {
        switch (group.ToLower())
        {
            case "mammalia":
            case "aves":
            case "reptilia":
            case "amphibia":
                break;
            default:
                return BadRequest("Unsupported class name");
        }
        Console.WriteLine("Getting all animals from group {0}. It could take a while", 0);
        var values = await _animalStore.GetByClass(group);
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

        var a = await _animalStore.Get(animal.Id);

        if (!(a is null)) return Conflict("Id already exists");

        await _animalStore.Create(animal);

        return Created($"animals/{animal.Id}", animal);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Create(int id, [FromBody] Animal animal)
    {
        Console.WriteLine("Saving an animal");
        var a = await _animalStore.Get(id);
        if (a is null) return NotFound();

        await _animalStore.Update(animal);

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