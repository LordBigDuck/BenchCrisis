using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Core.Models
{
    public class TeamMember
    {
        public Person Person { get; set; }
        public Team Team { get; set; }
        public bool IsLeader { get; set; }
    }
}
