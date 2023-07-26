using MediatR;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.CQRS.User.Request.Commands
{
    public class UpdateUserCommandModel : IRequest
    {
        public UpdateUserDto UpdateUser { get; set; }
    }
}
