using SampleZoo.Domain.Entities.User;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.DataLayer.Repository
{
    public class UserRepository : CrudRepository<User, int>, IUserRepository
    {

    }
}
