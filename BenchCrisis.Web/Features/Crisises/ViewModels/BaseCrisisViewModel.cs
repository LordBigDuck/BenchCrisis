using BenchCrisis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises.ViewModels
{
    public class BaseCrisisViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public static BaseCrisisViewModel Map(Crisis crisis)
        {
            return new BaseCrisisViewModel
            {
                Id = crisis.Id,
                Name = crisis.CrisisName.Value,
                Description = crisis.Description,
                Status = crisis.Status.ToString(),
                Teams = crisis.CrisisTeams?.Select(t => new Team
                {
                    Id = t.Team.Id,
                    Name = t.Team.Name,
                    Description = t.Team.Description
                }).ToList()
            };
        }

        public static IEnumerable<BaseCrisisViewModel> Map(IEnumerable<Crisis> crisisList)
        {
            var result = new List<BaseCrisisViewModel>();
            foreach (var crisis in crisisList)
            {
                var viewModel = Map(crisis);
                result.Add(viewModel);
            }
            return result;
        }
    }
}
