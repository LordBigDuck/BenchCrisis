using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchCrisis.Core.Models
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private ICollection<CrisisTeam> _crisisTeams;
        public virtual IReadOnlyCollection<CrisisTeam> CrisisTeams
        {
            get => _crisisTeams.ToList();
            private set => _crisisTeams = value.ToList();
        }
        //public ICollection<TeamMember> TeamMembers { get; set; }

        public Team() 
        {
            _crisisTeams = new List<CrisisTeam>();
        }

        public Team(string name, string description) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
