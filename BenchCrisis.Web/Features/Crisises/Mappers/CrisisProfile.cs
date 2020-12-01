using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using BenchCrisis.Core.Models;
using BenchCrisis.Web.Features.Crisises.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.Mappers
{
    public class CrisisProfile : Profile
    {
        public CrisisProfile()
        {
            CreateMap<Crisis, BaseCrisisViewModel>()
                .ForMember(vm => vm.Status, opt => opt.MapFrom(c => c.Status.ToString()))
                .ReverseMap();
            CreateMap<Team, BaseCrisisViewModel.Team>();
        }
    }
}
