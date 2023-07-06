using MediatR;

namespace Farm.Requests;

public class AddAnimalRequest : IRequest<IResult>
{
    public string Name { get; set; } = null!;
}
