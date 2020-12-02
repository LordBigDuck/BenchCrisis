using BenchCrisis.Core.Models;
using BenchCrisis.Infrastructure.Data;
using BenchCrisis.Web.Features.Crisises.Handlers;
using BenchCrisis.Web.Features.Crisises.Requests;
using BenchCrisis.Web.Features.Crisises.ViewModels;
using BenchCrisis.Web.Test.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BenchCrisis.Web.Test.Handlers
{
    public class CreateCrisisHandlerTest
    {
        [Fact]
        public async Task CreateCrisis_RequestTeamIdsEmpty_ReturnFail()
        {
            var request = new CreateCrisisRequest() { Name = "test", TeamIds = new List<int>() };
            using var context = new AppDbContext(DbHelper.GetDbContextOptions());
            var handler = new CreateCrisisHandler(context);

            var result = await handler.Handle(request, CancellationTokenHelper.GetCancellationToken());

            result.IsFailed.Should().BeTrue();
            result.WithError("Request team empty");
        }

        [Fact]
        public async Task CreateCrisis_NotAllTeamsFound_ReturnFail()
        {
            var context = new AppDbContext(DbHelper.GetDbContextOptions());
            context.Teams.Add(new Team(name: "Team 1", description: "Description 1"));
            context.Teams.Add(new Team(name: "Team 2", description: "Description 2"));
            context.SaveChanges();
            
            var request = new CreateCrisisRequest()
            {
                Name = "test",
                Description = "test",
                TeamIds = new List<int>() { 1, 2, 3 }
            };
            var handler = new CreateCrisisHandler(context);

            var result = await handler.Handle(request, CancellationTokenHelper.GetCancellationToken());

            result.IsFailed.Should().BeTrue();
            result.WithError("Not all teams found");
        }

        [Fact]
        public async Task CreateCrisis_RequestOk_ReturnViewModel()
        {
            using var context = new AppDbContext(DbHelper.GetDbContextOptions());
            context.Teams.Add(new Team(name: "Team 1", description: "Description 1"));
            context.Teams.Add(new Team(name: "Team 2", description: "Description 2"));
            context.SaveChanges();
            var request = new CreateCrisisRequest()
            {
                Name = "test",
                Description = "test",
                TeamIds = new List<int>() { 1, 2}
            };
            var handler = new CreateCrisisHandler(context);

            var result = await handler.Handle(request, CancellationTokenHelper.GetCancellationToken());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeOfType<BaseCrisisViewModel>();
            result.Value.Name.Should().Be("test");
            result.Value.Id.Should().NotBe(0);
            result.Value.Teams.Count.Should().Be(2);
        }
        
    }
}
