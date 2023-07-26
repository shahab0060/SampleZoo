using SampleZoo.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace SampleZoo.Domain.ViewModels.User
{
    public class UserListDto : BaseListDto<int>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class BaseChangeUserDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }

    public class CreateUserDto : BaseChangeUserDto
    {
        [Required]
        public string UserName { get; set; }
    }

    public class UpdateUserDto : BaseChangeUserDto
    {
        public int Id { get; set; }
    }

}
