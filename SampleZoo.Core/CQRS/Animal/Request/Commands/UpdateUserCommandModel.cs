using MediatR;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.CQRS.Animal.Request.Commands
{
    public class UpdateAnimalCommandModel : IRequest
    {
        public UpdateAnimalDto UpdateAnimal { get; set; }
    }
}
