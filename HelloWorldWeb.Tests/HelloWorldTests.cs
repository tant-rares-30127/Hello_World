using System;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class NewTeamServiceTests
    {
        private ITimeService timeService = new TimeService();

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            Member member = new Member("George", 5, timeService);
            teamService.AddTeamMemberAsync(member);

            // Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            Member member = new Member("George", 5, timeService);
            Member member2 = teamService.GetTeamInfo().TeamMembers[2];
            teamService.AddTeamMemberAsync(member);
            teamService.DeleteTeamMember(member);
            teamService.DeleteTeamMember(member2);

            // Assert
            Assert.Equal(3, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void EditTeamMember()
        {
            // Assume

            ITeamService teamService = new TeamService();

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
            ITeamService teamService = new TeamService();
            var teamMember = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMember = new Member("Borys", 5, timeService);

            // Act
            teamService.DeleteTeamMember(teamMember);
            teamService.AddTeamMemberAsync(newMember);
            teamService.DeleteTeamMember(newMember);

            // Assert
            newMember = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == "Borys");
            Assert.Null(newMember);
        }
    }
}
