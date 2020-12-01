using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<TeamMember> TeamMembers { get; set; }
    }
}
