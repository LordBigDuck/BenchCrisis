using BenchCrisis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Infrastructure.Data.Configurations
{
    public class CrisisConfiguration : IEntityTypeConfiguration<Crisis>
    {
        public void Configure(EntityTypeBuilder<Crisis> builder)
        {
            builder.ToTable("Crisis");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status)
                .HasConversion<string>();

            builder.OwnsOne(c => c.CrisisName)
                .Property(c => c.Value)
                .HasColumnName("Name");

            builder.HasMany(c => c.CrisisTeams)
                .WithOne(ct => ct.Crisis);
        }
    }
}
