using MediatR;

namespace SampleZoo.Core.CQRS.Animal.Request.Commands
{
    public class DeleteAnimalCommandModel : IRequest
    {
        public int AnimalId { get; set; }
    }
}
