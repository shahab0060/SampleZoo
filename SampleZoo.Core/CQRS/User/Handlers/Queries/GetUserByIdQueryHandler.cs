using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleZoo.Core.CQRS.User.Request.Queries;
using SampleZoo.DataLayer.Context;
using SampleZoo.Domain.ViewModels.User;

namespace SampleZoo.Core.CQRS.User.Handlers.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryModel, UserListDto?>
    {
        #region constructor

        private readonly SampleZooDbContext _context;
        public GetUserByIdQueryHandler(SampleZooDbContext context)
        {
            this._context = context;
        }

        #endregion

        public async Task<UserListDto?> Handle(GetUserByIdQueryModel request, CancellationToken cancellationToken)
        {
            UserListDto? user = await _context.Users
                 .Where(a => a.Id == request.Id)
                 .AsNoTracking()
                 .Select(a => new UserListDto()
                 {
                     Id = a.Id,
                     Password = a.Password,
                     PhoneNumber = a.PhoneNumber,
                     UserName = a.UserName
                 }).FirstOrDefaultAsync();
            return user;
        }
    }
}
