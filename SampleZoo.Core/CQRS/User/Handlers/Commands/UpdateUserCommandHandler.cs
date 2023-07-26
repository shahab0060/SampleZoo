using MediatR;
using SampleZoo.Core.CQRS.User.Request.Commands;
using SampleZoo.Core.Mappers;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Core.CQRS.User.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandModel>
    {
        #region constructor

        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion

        public async Task Handle(UpdateUserCommandModel request, CancellationToken cancellationToken)
        {
            Domain.Entities.User.User? user = await _userRepository.GetAsTracking(request.UpdateUser.Id);
            if (user is null)
                throw new ArgumentNullException("User Not Found!");
            user = user.ToModel(request.UpdateUser);
            _userRepository.Update(user);
            await _userRepository.SaveChanges();
        }
    }
}
