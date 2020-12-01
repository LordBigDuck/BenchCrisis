using BenchCrisis.Web.Features.Crisises.ViewModels;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Requests
{
    public class CreateCrisisRequest : IRequest<Result<BaseCrisisViewModel>>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public ICollection<int> TeamIds { get; init; } = new List<int>();
    }
}
