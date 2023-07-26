using MediatR;
using SampleZoo.Core.CQRS.Animal.Request.Commands;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Core.CQRS.Animal.Handlers.Commands
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommandModel>
    {
        #region constructor

        private readonly IAnimalRepository _AnimalRepository;
        public DeleteAnimalCommandHandler(IAnimalRepository AnimalRepository)
        {
            this._AnimalRepository = AnimalRepository;
        }

        #endregion

        public async Task Handle(DeleteAnimalCommandModel request, CancellationToken cancellationToken)
        {
            Domain.Entities.Animal.Animal? Animal = await _AnimalRepository.GetAsTracking(request.AnimalId);
            if (Animal is null) throw new Exception("Animal Not Found!");
            Animal.Delete();
            _AnimalRepository.Update(Animal);
            await _AnimalRepository.SaveChanges();
        }
    }
}
