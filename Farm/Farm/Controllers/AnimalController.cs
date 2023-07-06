using Farm.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farm.Controllers;

[ApiController, Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnimalController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public Task<ICollection<string>> GetAll()
        => _mediator.Send(new GetAnimalsRequest());

    [HttpPost]
    public Task<IResult> CreateAnimal([FromBody] AddAnimalRequest request)
        => _mediator.Send(request);


    [HttpDelete("{name}")]
    public Task<IResult> DeleteAnimal(string name)
        => _mediator.Send(new DeleteAnimalRequest { Name = name });
}