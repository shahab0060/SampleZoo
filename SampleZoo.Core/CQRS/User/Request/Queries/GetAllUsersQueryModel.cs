using MediatR;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.CQRS.User.Request.Queries
{
    public class GetAllUsersQueryModel : IRequest<List<UserListDto>>
    {

    }
}
