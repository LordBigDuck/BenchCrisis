using AutoMapper;
using BenchCrisis.Core.Models;
using BenchCrisis.Core.Models.Enums;
using BenchCrisis.Core.Models.ValueObjects;
using BenchCrisis.Infrastructure.Data;
using BenchCrisis.Web.Features.Crisises.Requests;
using BenchCrisis.Web.Features.Crisises.ViewModels;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Handlers
{
    public class CreateCrisisHandler : IRequestHandler<CreateCrisisRequest, Result<BaseCrisisViewModel>>
    {
        public readonly AppDbContext _dbContext;

        public CreateCrisisHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<BaseCrisisViewModel>> Handle(CreateCrisisRequest request, CancellationToken cancellationToken)
        {
            if (request.TeamIds.Count == 0) return Result.Fail("Request team empty");

            var teams = await _dbContext
                .Teams
                .Where(t => request.TeamIds.Contains(t.Id))
                .ToListAsync(cancellationToken);
            if (teams.Count != request.TeamIds.Count) return Result.Fail("Not all teams found");

            var crisisName = CrisisName.Create(request.Name);
            if (crisisName.IsFailed)
            {
                // TODO return result error
            }

            var crisis = new Crisis(crisisName.Value, request.Description);
            foreach (var team in teams)
            {
                var result = crisis.AddTeam(team);
            }

            _dbContext.Crisises.Add(crisis);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var viewModel = BaseCrisisViewModel.Map(crisis);
            return Result.Ok(viewModel);
        }
    }
}
