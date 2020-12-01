using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Test.Helpers
{
    public static class MapperHelper
    {
        public static Mapper GetMapper(Profile profile)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return new Mapper(mapperConfiguration); ;
        }
    }
}
