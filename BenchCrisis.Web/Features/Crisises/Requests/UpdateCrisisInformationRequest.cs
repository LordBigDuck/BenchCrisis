using FluentResults;
using MediatR;

namespace BenchCrisis.Web.Features.Crisises.Requests
{
    public class UpdateCrisisInformationRequest : IRequest<Result>
    {
        public int CrisisId { get; init; }
        public string Description { get; init; }
    }
}
