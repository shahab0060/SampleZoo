using SampleZoo.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace SampleZoo.Domain.ViewModels.Animal
{
    public class AnimalListDto : BaseListDto<int>
    {
        public string Title { get; set; }

        public int Age { get; set; }
    }

    public class BaseChangeAnimalDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Age { get; set; }
    }

    public class CreateAnimalDto : BaseChangeAnimalDto
    {
       
    }

    public class UpdateAnimalDto : BaseChangeAnimalDto
    {
        public int Id { get; set; }
    }

}
