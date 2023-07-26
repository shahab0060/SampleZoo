using MediatR;
using SampleZoo.Core.CQRS.User.Request.Commands;
using SampleZoo.Core.Mappers;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Core.CQRS.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandModel>
    {
        #region constructor

        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion

        public async Task Handle(CreateUserCommandModel request, CancellationToken cancellationToken)
        {
            Domain.Entities.User.User user = request.CreateUser.ToModel();
            await _userRepository.Add(user);
            await _userRepository.SaveChanges();
        }
    }
}
