using MediatR;
using SampleZoo.Core.CQRS.User.Request.Commands;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Core.CQRS.User.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandModel>
    {
        #region constructor

        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion

        public async Task Handle(DeleteUserCommandModel request, CancellationToken cancellationToken)
        {
            Domain.Entities.User.User? user = await _userRepository.GetAsTracking(request.UserId);
            if (user is null) throw new Exception("User Not Found!");
            user.Delete();
            _userRepository.Update(user);
            await _userRepository.SaveChanges();
        }
    }
}
