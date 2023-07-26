using SampleZoo.Domain.Entities.Animal;

namespace SampleZoo.Domain.IRepository
{
    public interface IAnimalRepository : IRepository, IReadRepository<Animal, int>, IWriteRepository<Animal, int>
    {

    }
}
