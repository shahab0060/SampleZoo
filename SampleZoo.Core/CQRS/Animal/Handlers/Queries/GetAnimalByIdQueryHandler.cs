using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleZoo.Core.CQRS.Animal.Request.Queries;
using SampleZoo.DataLayer.Context;
using SampleZoo.Domain.ViewModels.Animal;

namespace SampleZoo.Core.CQRS.Animal.Handlers.Queries
{
    public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQueryModel, AnimalListDto?>
    {
        #region constructor

        private readonly SampleZooDbContext _context;
        public GetAnimalByIdQueryHandler(SampleZooDbContext context)
        {
            this._context = context;
        }

        #endregion

        public async Task<AnimalListDto?> Handle(GetAnimalByIdQueryModel request, CancellationToken cancellationToken)
        {
            AnimalListDto? Animal = await _context.Animals
                 .Where(a => a.Id == request.Id)
                 .AsNoTracking()
                 .Select(a => new AnimalListDto()
                 {
                     Id = a.Id,
                     Age = a.Age,
                     Title = a.Title
                 }).FirstOrDefaultAsync();
            return Animal;
        }
    }
}
