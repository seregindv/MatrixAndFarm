using MediatR;

namespace Farm.Requests;

public class GetAnimalsRequest : IRequest<ICollection<string>>
{
}
