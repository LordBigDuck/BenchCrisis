using BenchCrisis.Infrastructure.Data;
using BenchCrisis.Web.Features.Crisises.Requests;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Handlers
{
    public class UpdateCrisisTeamsHandler : IRequestHandler<UpdateCrisisTeamsRequest, Result>
    {
        public readonly AppDbContext _dbContext;

        public UpdateCrisisTeamsHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(UpdateCrisisTeamsRequest request, CancellationToken cancellationToken)
        {
            var crisis = await _dbContext.Crisises
                .Include(c => c.CrisisTeams)
                    .ThenInclude(ct => ct.Team)
                .SingleOrDefaultAsync(c => c.Id == request.CrisisId, cancellationToken);
            if (crisis == null)
                return Result.Fail("Crisis not found");

            var teams = await _dbContext
                .Teams
                .Where(t => request.TeamIds.Contains(t.Id))
                .ToListAsync(cancellationToken);
            if (teams.Count != request.TeamIds.Count) 
                return Result.Fail("Not all teams found");

            crisis.UpdateTeams(teams);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
