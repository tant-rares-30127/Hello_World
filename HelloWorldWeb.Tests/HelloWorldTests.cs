using System;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class NewTeamServiceTests
    {
        private ITimeService timeService;
        private IHubContext<MessageHub> messageHub;
        private IBroadcastServices broadcastService;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            Mock<IBroadcastServices> broadcastServiceMock = new Mock<IBroadcastServices>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);

            // Act

            Member member = new Member("George", 5, timeService);
            teamService.AddTeamMember(member);

            // Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
            broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), 5), Times.Once);

        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume
            Mock<IBroadcastServices> broadcastServiceMock = new Mock<IBroadcastServices>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);

            // Act

            Member member = new Member("George", 5, timeService);
            Member member2 = teamService.GetTeamInfo().TeamMembers[2];
            teamService.AddTeamMember(member);
            teamService.DeleteTeamMember(member);
            teamService.DeleteTeamMember(member2);

            // Assert
            Assert.Equal(3, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void EditTeamMember()
        {
            // Assume

            ITeamService teamService = new TeamService(broadcastService);

            // Act

            teamService.EditTeamMember(3, "NewName");

            // Assert

            Assert.Equal("NewName", teamService.GetTeamInfo().TeamMembers[3].Name);
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void CheckIdWhenDeleted()
        {
            // Assume
            Mock<IBroadcastServices> broadcastServiceMock = new Mock<IBroadcastServices>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
            var teamMember = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMember = new Member("Borys", 5, timeService);

            // Act
            teamService.DeleteTeamMember(teamMember);
            teamService.AddTeamMember(newMember);
            teamService.DeleteTeamMember(newMember);

            // Assert
            newMember = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == "Borys");
            Assert.Null(newMember);
        }
    }
}
