using BenchCrisis.Infrastructure.Data;
using BenchCrisis.Web.Features.Crisises.Requests;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Handlers
{
    public class UpdateCrisisInformationHandler : IRequestHandler<UpdateCrisisInformationRequest, Result>
    {
        public readonly AppDbContext _dbContext;

        public UpdateCrisisInformationHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(UpdateCrisisInformationRequest request, CancellationToken cancellationToken)
        {
            var crisis = await _dbContext.Crisises
                .SingleOrDefaultAsync(c => c.Id == request.CrisisId, cancellationToken);
            if (crisis == null)
                return Result.Fail("Crisis not found");

            crisis.UpdateDescription(request.Description);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
