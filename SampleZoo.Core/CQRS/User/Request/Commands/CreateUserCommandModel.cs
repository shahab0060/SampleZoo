using MediatR;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.CQRS.User.Request.Commands
{
    public class CreateUserCommandModel : IRequest
    {
        public CreateUserDto CreateUser { get; set; }
    }
}
