using SampleZoo.Domain.Entities.User;

namespace SampleZoo.Domain.IRepository
{
    public interface IUserRepository : IRepository,
        IReadRepository<User, int>,
        IWriteRepository<User, int>
    {

    }
}
