using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleZoo.Core.CQRS.Animal.Request.Queries;
using SampleZoo.DataLayer.Context;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.CQRS.Animal.Handlers.Queries
{
    public class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQueryModel, IEnumerable<AnimalListDto>>
    {
        #region constructor

        private readonly SampleZooDbContext _context;
        public GetAllAnimalsQueryHandler(SampleZooDbContext context)
        {
            this._context = context;
        }

        #endregion

        public async Task<IEnumerable<AnimalListDto>> Handle(GetAllAnimalsQueryModel request, CancellationToken cancellationToken)
        {
            List<AnimalListDto> Animals = await _context.Animals
                  .AsNoTracking()
                  .Select(a => new AnimalListDto()
                  {
                      Id = a.Id,
                      Age = a.Age,
                      Title = a.Title
                  }).ToListAsync();
            return Animals.AsReadOnly();
        }
    }
}
