using MediatR;
using SampleZoo.Core.CQRS.Animal.Request.Commands;
using SampleZoo.Core.Mappers;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Core.CQRS.Animal.Handlers.Commands
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommandModel>
    {
        #region constructor

        private readonly IAnimalRepository _AnimalRepository;
        public UpdateAnimalCommandHandler(IAnimalRepository AnimalRepository)
        {
            this._AnimalRepository = AnimalRepository;
        }

        #endregion

        public async Task Handle(UpdateAnimalCommandModel request, CancellationToken cancellationToken)
        {
            Domain.Entities.Animal.Animal? Animal = await _AnimalRepository.GetAsTracking(request.UpdateAnimal.Id);
            if (Animal is null)
                throw new ArgumentNullException("Animal Not Found!");
            Animal = Animal.ToModel(request.UpdateAnimal);
            _AnimalRepository.Update(Animal);
            await _AnimalRepository.SaveChanges();
        }
    }
}
