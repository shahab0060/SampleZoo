using MediatR;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.CQRS.Animal.Request.Commands
{
    public class CreateAnimalCommandModel : IRequest
    {
        public CreateAnimalDto CreateAnimal { get; set; }
    }
}
