using SampleZoo.Domain.Entities.User;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.Mappers
{
    public static class UserMappers
    {
        public static User ToModel(this CreateUserDto createUser)
        => new User(createUser.UserName, createUser.PhoneNumber, createUser.Password);

        public static User ToModel(this User user, UpdateUserDto updateUser)
        {
            user.Update(updateUser.PhoneNumber, updateUser.Password);
            return user;
        }
    }
}
