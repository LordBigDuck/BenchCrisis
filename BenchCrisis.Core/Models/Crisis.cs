using BenchCrisis.Core.Models.Enums;
using BenchCrisis.Core.Models.ValueObjects;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchCrisis.Core.Models
{
#nullable enable
    public class Crisis
    {
        public int Id { get; private set;  }
        public CrisisStatus Status { get; private set; }

        private string _crisisName;
        public CrisisName CrisisName
        {
            get => (CrisisName)_crisisName;
            private set => _crisisName = value;
        }

        public string? Description { get; private set; }

        private ICollection<CrisisTeam> _crisisTeams;
        //public virtual IReadOnlyCollection<CrisisTeam> CrisisTeams => _crisisTeams.ToList();
        public virtual IReadOnlyCollection<CrisisTeam> CrisisTeams
        {
            get => _crisisTeams.ToList();
            private set => _crisisTeams = value.ToList();
        }

        protected Crisis()
        {
            _crisisTeams = new List<CrisisTeam>();
        }

        public Crisis(CrisisName crisisName, string? description = null) : this()
        {
            _crisisName = crisisName ?? throw new ArgumentNullException(nameof(crisisName));
            Description = description;

            Status = CrisisStatus.ONGOING;
        }

        public Result AddTeam(Team team)
        {
            if (ContainsTeam(team))
                return Result.Fail("Team already in list");

            var crisisTeam = new CrisisTeam(this, team);
            _crisisTeams.Add(crisisTeam);
            return Result.Ok();
        }

        public bool ContainsTeam(Team team)
        {
            return _crisisTeams.Any(ct => ct.Team.Id == team.Id);
        }

        public Result RemoveTeam(Team team)
        {
            if (!ContainsTeam(team))
                return Result.Fail("Crisis does not contain this team");

            var crisisTeam = new CrisisTeam(this, team);
            var itemToRemove = _crisisTeams.Single(c => c.Team.Id == team.Id);
            _crisisTeams.Remove(itemToRemove);
            return Result.Ok();
        }

        public void StopCrisis()
        {
            Status = CrisisStatus.ENDED;
        }
    }
}
