using BenchCrisis.Web.Features.Crisises.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Requests
{
    public class GetCrisisByIdRequest : IRequest<BaseCrisisViewModel>
    {
        public int Id { get; set; }
    }
}
