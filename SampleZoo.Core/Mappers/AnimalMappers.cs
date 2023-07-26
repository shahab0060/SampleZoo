using SampleZoo.Domain.Entities.Animal;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.Mappers
{
    public static class AnimalMappers
    {
        public static Animal ToModel(this CreateAnimalDto createAnimal)
        => new Animal(createAnimal.Title, createAnimal.Age);

        public static Animal ToModel(this Animal Animal, UpdateAnimalDto updateAnimal)
        {
            Animal.Update(updateAnimal.Title, updateAnimal.Age);
            return Animal;
        }
    }
}
