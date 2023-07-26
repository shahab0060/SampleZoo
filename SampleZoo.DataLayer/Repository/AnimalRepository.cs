using SampleZoo.Domain.Entities.Animal;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.DataLayer.Repository
{
    public class AnimalRepository : CrudRepository<Animal,int> , IAnimalRepository
    {

    }
}
