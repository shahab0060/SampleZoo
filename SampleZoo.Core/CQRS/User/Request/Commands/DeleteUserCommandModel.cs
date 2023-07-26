using MediatR;

namespace SampleZoo.Core.CQRS.User.Request.Commands
{
    public class DeleteUserCommandModel : IRequest
    {
        public int UserId { get; set; }
    }
}
