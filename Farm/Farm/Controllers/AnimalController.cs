using Farm.Data;
using Farm.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers;

[ApiController, Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public ICollection<string> GetAll() => _animalService.GetAnimals();

    [HttpPost]
    public IResult CreateAnimal([FromBody] CreateAnimalRequest reqeust)
    {
        if(!ModelState.IsValid)
            return Results.UnprocessableEntity(reqeust);
        
        return _animalService.Add(reqeust.Name) ? Results.CreatedAtRoute() : Results.Conflict();
    }

    [HttpDelete("{name}")]
    public IResult DeleteAnimal(string name)
        => _animalService.Delete(name) ? Results.NoContent() : Results.NotFound();
}