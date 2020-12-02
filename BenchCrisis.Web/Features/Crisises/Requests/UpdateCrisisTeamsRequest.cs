using BenchCrisis.Web.Features.Crisises.ViewModels;
using FluentResults;
using MediatR;
using System.Collections.Generic;

namespace BenchCrisis.Web.Features.Crisises.Requests
{

    public class UpdateCrisisTeamsRequest : IRequest<Result>
    {
        public int CrisisId { get; init; }
        public ICollection<int> TeamIds { get; init; }
    }
}
