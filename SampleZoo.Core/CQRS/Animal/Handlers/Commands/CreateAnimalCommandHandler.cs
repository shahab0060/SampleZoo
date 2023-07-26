using MediatR;
using SampleZoo.Core.CQRS.Animal.Request.Commands;
using SampleZoo.Core.Mappers;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Core.CQRS.Animal.Handlers.Commands
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommandModel>
    {
        #region constructor

        private readonly IAnimalRepository _AnimalRepository;
        public CreateAnimalCommandHandler(IAnimalRepository AnimalRepository)
        {
            this._AnimalRepository = AnimalRepository;
        }

        #endregion

        public async Task Handle(CreateAnimalCommandModel request, CancellationToken cancellationToken)
        {
            Domain.Entities.Animal.Animal Animal = request.CreateAnimal.ToModel();
            await _AnimalRepository.Add(Animal);
            await _AnimalRepository.SaveChanges();
        }
    }
}
