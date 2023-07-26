using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleZoo.Core.CQRS.User.Request.Queries;
using SampleZoo.DataLayer.Context;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.CQRS.User.Handlers.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryModel, IEnumerable<UserListDto>>
    {
        #region constructor

        private readonly SampleZooDbContext _context;
        public GetAllUsersQueryHandler(SampleZooDbContext context)
        {
            this._context = context;
        }

        #endregion

        public async Task<IEnumerable<UserListDto>> Handle(GetAllUsersQueryModel request, CancellationToken cancellationToken)
        {
           List<UserListDto> users = await _context.Users
                 .AsNoTracking()
                 .Select(a => new UserListDto()
                 {
                     Id = a.Id,
                     Password = a.Password,
                     PhoneNumber = a.PhoneNumber,
                     UserName = a.UserName
                 }).ToListAsync();
            return users.AsReadOnly();
        }
    }
}
