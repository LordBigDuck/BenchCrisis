using BenchCrisis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Infrastructure.Data.Configurations
{
    public class CrisisTeamConfiguration : IEntityTypeConfiguration<CrisisTeam>
    {
        public void Configure(EntityTypeBuilder<CrisisTeam> builder)
        {
            //builder.HasKey(ct => new { ct.CrisisId, ct.TeamId });
            builder.HasKey(ct => ct.Id);

            builder.HasOne(ct => ct.Crisis)
                .WithMany(c => c.CrisisTeams);

            builder.HasOne(ct => ct.Team)
                .WithMany();
        }
    }
}
