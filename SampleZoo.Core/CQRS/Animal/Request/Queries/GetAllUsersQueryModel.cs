using MediatR;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.CQRS.Animal.Request.Queries
{
    public class GetAllAnimalsQueryModel : IRequest<List<AnimalListDto>>
    {

    }
}
