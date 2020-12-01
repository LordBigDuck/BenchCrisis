using BenchCrisis.Core.Models;
using BenchCrisis.Core.Models.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BenchCrisis.Core.Test
{
    public class CrisisTest
    {
        [Fact]
        public void RemoveTeam_TeamRemoved_ReturnOk()
        {
            var team1 = new Team { Id = 1, Name = "Team 1", Description = "desc 1" };
            var team2 = new Team { Id = 2, Name = "Team 2", Description = "desc 2" };
            var crisisName = CrisisName.Create("crisis 1");
            var crisis = new Crisis(crisisName.Value, "crisis description");
            crisis.AddTeam(team1);
            crisis.AddTeam(team2);

            var result = crisis.RemoveTeam(team1);

            crisis.CrisisTeams.Count.Should().Be(1);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void RemoveTeam_TeamDoesntExist_ReturnFail()
        {
            var team1 = new Team { Id = 1, Name = "Team 1", Description = "desc 1" };
            var team2 = new Team { Id = 2, Name = "Team 2", Description = "desc 2" };
            var crisisName = CrisisName.Create("crisis 1");
            var crisis = new Crisis(crisisName.Value, "crisis description");
            crisis.AddTeam(team1);

            var result = crisis.RemoveTeam(team2);

            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void AddTeam_TeamAlreadyExist_ReturnFail()
        {
            var team1 = new Team { Id = 1, Name = "Team 1", Description = "desc 1" };
            var crisisName = CrisisName.Create("crisis 1");
            var crisis = new Crisis(crisisName.Value, "crisis description");
            crisis.AddTeam(team1);

            var result = crisis.AddTeam(team1);

            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void AddTeam_TeamAdded_ReturnOk()
        {
            var team1 = new Team { Id = 1, Name = "Team 1", Description = "desc 1" };
            var team2 = new Team { Id = 2, Name = "Team 2", Description = "desc 2" };
            var crisisName = CrisisName.Create("crisis 1");
            var crisis = new Crisis(crisisName.Value, "crisis description");
            crisis.AddTeam(team1);

            var result = crisis.AddTeam(team2);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
