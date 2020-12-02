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
    public class GetAllCrisisHandler : IRequestHandler<GetAllCrisisRequest, ICollection<BaseCrisisViewModel>>
    {
        public readonly AppDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetAllCrisisHandler(AppDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<BaseCrisisViewModel>> Handle(GetAllCrisisRequest request, CancellationToken cancellationToken)
        {
            var crisises = await _dbContext
                .Crisises
                .Include(c => c.CrisisTeams)
                .ToListAsync(cancellationToken);

            var viewModel = BaseCrisisViewModel.Map(crisises).ToList();
            return viewModel;
        }
    }
}
