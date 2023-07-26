using MediatR;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.CQRS.Animal.Request.Queries
{
    public class GetAnimalByIdQueryModel : IRequest<AnimalListDto?>
    {
        public long Id { get; set; }
    }
}
