using Farm.Requests;
using Farm.Services.Contracts;
using MediatR;

namespace Farm.Handlers;

public class AddAnimalHandler : IRequestHandler<AddAnimalRequest, IResult>
{
    private readonly IAnimalService _animalService;

    public AddAnimalHandler(IAnimalService animalService)
        => _animalService = animalService;

    public Task<IResult> Handle(AddAnimalRequest request, CancellationToken cancellationToken)
        => Task.FromResult(_animalService.Add(request.Name) ? Results.CreatedAtRoute() : Results.Conflict());
}
