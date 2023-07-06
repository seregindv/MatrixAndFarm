using Farm.Requests;
using Farm.Services.Contracts;
using MediatR;

namespace Farm.Handlers;

public class DeleteAnimalRequestHandler : IRequestHandler<DeleteAnimalRequest, IResult>
{
    private readonly IAnimalService _animalService;

    public DeleteAnimalRequestHandler(IAnimalService animalService)
        => _animalService = animalService;

    public Task<IResult> Handle(DeleteAnimalRequest request, CancellationToken cancellationToken)
        => Task.FromResult(_animalService.Delete(request.Name) ? Results.NoContent() : Results.NotFound());
}
