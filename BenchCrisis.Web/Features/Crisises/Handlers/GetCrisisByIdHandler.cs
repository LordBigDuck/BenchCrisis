using AutoMapper;
using BenchCrisis.Infrastructure.Data;
using BenchCrisis.Web.Features.Crisises.Requests;
using BenchCrisis.Web.Features.Crisises.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Handlers
{
    public class GetCrisisByIdHandler : IRequestHandler<GetCrisisByIdRequest, BaseCrisisViewModel>
    {
        public readonly AppDbContext _dbContext;
        public readonly IMapper _mapper;

        public async Task<BaseCrisisViewModel> Handle(GetCrisisByIdRequest request, CancellationToken cancellationToken)
        {
            var crisis = await _dbContext.Crisises
                .Include(c => c.CrisisTeams)
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            var viewModel = _mapper.Map<BaseCrisisViewModel>(crisis);
            return viewModel;
        }
    }
}
