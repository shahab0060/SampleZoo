using MediatR;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.CQRS.User.Request.Queries
{
    public class GetUserByIdQueryModel : IRequest<UserListDto?>
    {
        public long Id { get; set; }
    }
}
