using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Core.Models
{
    public class CrisisTeam
    {
        //public int CrisisId { get; private set; }

        //public int TeamId { get; private set; }
        public int Id { get; private set; }

        public Crisis Crisis { get; protected set; }
        public Team Team { get; protected set; }

        protected CrisisTeam() { }

        internal CrisisTeam(Crisis crisis, Team team)
        {
            Crisis = crisis ?? throw new ArgumentNullException(nameof(crisis));
            Team = team ?? throw new ArgumentNullException(nameof(team));
            //CrisisId = Crisis.Id;
            //TeamId = Team.Id;
        }
    }
}
