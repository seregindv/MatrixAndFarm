using Farm.Requests;
using Farm.Services.Contracts;
using MediatR;

namespace Farm.Handlers;

public class GetAnimalsHandler : IRequestHandler<GetAnimalsRequest, ICollection<string>>
{
    private readonly IAnimalService _animalService;

    public GetAnimalsHandler(IAnimalService animalService)
        => _animalService = animalService;

    public Task<ICollection<string>> Handle(GetAnimalsRequest request, CancellationToken cancellationToken)
        => Task.FromResult(_animalService.GetAnimals());
}
