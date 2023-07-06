using MediatR;

namespace Farm.Requests;

public class DeleteAnimalRequest : IRequest<IResult>
{
    public string Name { get; set; } = null!;
}
